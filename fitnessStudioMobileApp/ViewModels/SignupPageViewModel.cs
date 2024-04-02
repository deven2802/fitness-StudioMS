using fitnessStudioMobileApp.Views;
using fitnessStudioMobileApp.Services;
using fitnessStudioMobileApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using Firebase.Auth;
using Newtonsoft.Json;
using CommunityToolkit.Maui.Views;
using Syncfusion.Maui.Inputs;
using textInputLayout = Syncfusion.Maui.Core.SfTextInputLayout;
using System.Diagnostics;

namespace fitnessStudioMobileApp.ViewModels
{
    public partial class SignupPageViewModel : ObservableObject, INotifyPropertyChanged
    {
        //navigate to signupPage2
        [RelayCommand]
        public async Task GoToSignupPage2()
        {
            await Shell.Current.GoToAsync("SignupPage2");
        }

        //navigate to loginPage
        [RelayCommand]
        public async Task BackToLoginPage()
        {
            await Shell.Current.GoToAsync("LoginPage");
        }

        //navigate to signupPage
        [RelayCommand]
        public async Task GoToSignupPage()
        {
            await Shell.Current.GoToAsync("SignupPage");
        }


        //web APIkey
        public string webApiKey = "AIzaSyBbQIxyNOIAkyA-A5Wvuz5TrSsXJtOGvLc";

        //email authentication
        public new event PropertyChangedEventHandler PropertyChanged;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string homeAddress;

        [ObservableProperty]
        private string phoneNumber;

        private string userName;

        private string userPassword;

        private string email;

        private string password;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }

        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        private PersonalInfo _personalInfo;
        public PersonalInfo PersonalInfo
        {
            get => _personalInfo;
            set => SetProperty(ref _personalInfo, value);
        }

        //email authentication code
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Command RegisterUserCommand { get; }
        public ICommand ButtonSendLinkCommand { get; }
        public ICommand OnLogoutButtonCommand { get; }


        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public SignupPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandTappedAsync);
            LoginCommand = new Command(LoginCommandTappedAsync);
            RegisterUserCommand = new Command(RegisterUserCommandTappedAsync);
            OnLogoutButtonCommand = new Command(async () => await OnLogoutButtonAsync());
            ButtonSendLinkCommand = new RelayCommand(SendPasswordResetEmailAsync);

            LoadUserProfile();

        }

        public void LoadUserProfile()
        {
            var personalInfoJson = Preferences.Get("PersonalInfo", string.Empty);
            if (!string.IsNullOrEmpty(personalInfoJson))
            {
                Debug.WriteLine("Loading user profile...");

                PersonalInfo = JsonConvert.DeserializeObject<PersonalInfo>(personalInfoJson);
                // Update ViewModel properties with loaded data
                FullName = PersonalInfo.FullName;
                Email = PersonalInfo.Email;
                PhoneNumber = PersonalInfo.PhoneNumber;
                HomeAddress = PersonalInfo.HomeAddress;
            }
        }

        //get the registered email and password from the signupPage, and validate the email and password is correct
        private async void LoginCommandTappedAsync(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await Shell.Current.GoToAsync("//main");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private void RegisterCommandTappedAsync(object obj)
        {

        }

        private async void RegisterUserCommandTappedAsync()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                var personalInfo = new PersonalInfo
                {
                    FullName = this.FullName,
                    Email = this.Email,
                    PhoneNumber = this.PhoneNumber,
                    HomeAddress = this.HomeAddress
                };
                if (token != null)
                {
                    var personalInfoJson = JsonConvert.SerializeObject(personalInfo);
                    Preferences.Set("PersonalInfo", personalInfoJson);
                    await App.Current.MainPage.DisplayAlert("Congratulation!", "User Registered successfully", "OK");
                    await Shell.Current.GoToAsync("LoginPage");

                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        //reset the password show here
        private async void SendPasswordResetEmailAsync()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Please enter your registered email!", "OK");
                // Notify user to enter an email address
                return;
            }

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                await authProvider.SendPasswordResetEmailAsync(Email);
                await App.Current.MainPage.DisplayAlert("Success", "Password reset link has been sent to your email.", "OK");
                // Notify user that email has been sent
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                // Handle any errors that occur during the process
            }
        }

        private async Task OnLogoutButtonAsync()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            var token = Preferences.Get("FreshFirebaseToken", defaultValue: null);
            bool confirmLogout = await App.Current.MainPage.DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");

            try
            {
                if (confirmLogout)
                {
                    // Check if a token exists before trying to remove it.
                    var tokenExists = Preferences.ContainsKey("FreshFirebaseToken");
                    if (tokenExists)
                    {
                        // Clear the locally stored authentication token or any other user details
                        Preferences.Remove("FreshFirebaseToken");
                        // Optionally, clear all preferences if suitable for your application
                        // Preferences.Clear();
                    }

                    // Navigate to LoginPage
                    await Shell.Current.GoToAsync("//WelcomePage", true);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Logout error: {ex.Message}");
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public async Task LoadDataAsync()
        {
            var firebaseDatabase = DependencyService.Get<IFirebaseDatabase>();
            var data = await firebaseDatabase.GetDataAsync("your/path/here");
            // Use the data as needed in your ViewModel
        }

    }
}
