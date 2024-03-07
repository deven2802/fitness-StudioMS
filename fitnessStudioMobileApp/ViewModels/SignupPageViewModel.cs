using fitnessStudioMobileApp.Views;
using fitnessStudioMobileApp.Model;
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
using Syncfusion.Maui.DataForm;
using Syncfusion.Maui.Inputs;
using core = Syncfusion.Maui.Core;
using Syncfusion.Maui.Core;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using Firebase.Auth;
using Newtonsoft.Json;
using CommunityToolkit.Maui.Views;
using System.ComponentModel.DataAnnotations;

namespace fitnessStudioMobileApp.ViewModels
{
    public partial class SignupPageViewModel : ObservableObject, INotifyPropertyChanged
    {
        private void ValidateText()
        {
            this.FieldNullCheck(FirstNameFieldMobile);
            this.FieldNullCheck(PhoneNumberFieldMobile);
            this.FieldNullCheck(PasswordFieldMobile);
            this.FieldNullCheck(ConfirmPasswordFieldMobile);
            this.FieldNullCheck(EmailFieldMobile);
            ValidatePhoneNumber();
            ValidateEmailAddress();
            ValidatePasswordField();
        }

        private void ValidatePasswordField()
        {
            if (ConfirmPasswordFieldMobile.IsEnabled && ConfirmPasswordFieldMobile.Text != PasswordFieldMobile.Text)
            {
                ConfirmPasswordFieldMobile.HasError = true;
            }
            else
            {
                ConfirmPasswordFieldMobile.HasError = false;
            }

            if (string.IsNullOrEmpty(PasswordFieldMobile.Text) || PasswordFieldMobile.Text?.Length < 5 || PasswordFieldMobile.Text?.Length > 8)
            {
                PasswordFieldMobile.HasError = true;
            }
            else
            {
                PasswordFieldMobile.HasError = false;
            }
        }

        private void ValidatePhoneNumber()
        {
            if (!double.TryParse(PhoneNumberFieldMobile.Text, out double result))
            {
                PhoneNumberFieldMobile.HasError = true;
            }
            else
            {
                PhoneNumberFieldMobile.HasError = false;
            }
        }

        private void ValidateEmailAddress()
        {
            if (EmailFieldMobile.Text == null || !EmailFieldMobile.Text.Contains("@") || !EmailFieldMobile.Text.Contains("."))
            {
                EmailFieldMobile.HasError = true;
            }
            else
            {
                EmailFieldMobile.HasError = false;
            }
        }

        private void FieldNullCheck(core.SfTextInputLayout inputLayout)
        {
            if (string.IsNullOrEmpty(inputLayout.Text))
            {
                inputLayout.HasError = true;
            }
            else
            {
                inputLayout.HasError = false;
            }
        }



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
        public async Task OnForgetPasswordPage()
        {
            System.Diagnostics.Debug.WriteLine("Navigating to ForgotPasswordPage");
            await Shell.Current.GoToAsync(nameof(ForgotPasswordPage));
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
            set {
                email = value;
                RaisePropertyChanged("Email");
                ValidateText();
            }  
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged("Password");
                ValidateText();
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

            this.SignInFormModel = new SignInFormModel();
        }

        /// <summary>
        /// Gets or sets the sign in model.
        /// </summary>
        public SignInFormModel SignInFormModel { get; set; }

        public SfTextInputLayout FirstNameFieldMobile { get; private set; }

        public SfTextInputLayout EmailFieldMobile { get; private set; }

        public SfTextInputLayout PasswordFieldMobile { get; private set; }

        public SfTextInputLayout ConfirmPasswordFieldMobile { get; private set; }

        public SfTextInputLayout PhoneNumberFieldMobile { get; private set; }

        public SfTextInputLayout HomeAddressFieldMobile { get; private set; }



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
