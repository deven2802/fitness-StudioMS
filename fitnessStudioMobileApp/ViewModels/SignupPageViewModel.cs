using fitnessStudioMobileApp.Views;
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

namespace fitnessStudioMobileApp.ViewModels
{
    public partial class SignupPageViewModel : ObservableObject
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

        //navigate to homePage
        [RelayCommand]
        public async Task Register()
        {
            await Shell.Current.GoToAsync("//main");
        }

        //password validation
        private string _password;
        private string _confirmPassword;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    ConfirmPasswordChanged();
                }
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword;}
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value; 
                    OnPropertyChanged();
                    ConfirmPasswordChanged();
                }
            }
        }

        private void ConfirmPasswordChanged()
        {
            if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && Password != ConfirmPassword)
                    {
                //Display error message here
                    }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
