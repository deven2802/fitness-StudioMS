using fitnessStudioMobileApp.Views;
using fitnessStudioMobileApp.Services;
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

        //navigate to forgotPasswordPage
        [RelayCommand]
        public async Task OnForgotPasswordPage()
        {
            await Shell.Current.GoToAsync("ForgotPasswordPage");
        }

        //navigate to signupPage
        [RelayCommand]
        public async Task GoToSignupPage()
        {
            await Shell.Current.GoToAsync("SignupPage");
        }

        //navigate to forgotPasswordPage
        [RelayCommand]
        public async Task OnForgetPasswordPage()
        {
            await Shell.Current.GoToAsync("ForgotPasswordPage");
        }

        //web APIkey
        public string webApiKey = "AIzaSyBbQIxyNOIAkyA-A5Wvuz5TrSsXJtOGvLc";

        //email authentication
        public new event PropertyChangedEventHandler PropertyChanged;

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
                RaisePropertyChanged("Password");
            }
        }

        public string Email
        { 
            get => email; 
            set {
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

        //email authentication code
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public Command RegisterUserCommand { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public SignupPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandTappedAsync);
            LoginCommand = new Command(LoginCommandTappedAsync);
            RegisterUserCommand = new Command(RegisterUserCommandTappedAsync);
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

        private async void RegisterUserCommandTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Congratulation!", "User Registered successfully", "OK");
                await Shell.Current.GoToAsync("LoginPage");
                
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
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
