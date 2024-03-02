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

namespace fitnessStudioMobileApp.ViewModels
{
    public partial class SignupPageViewModel : ObservableObject
    {
        //navigate to other pages command code
        [RelayCommand]
        public async void BackToLoginPage()
        {

        }


        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                CheckPasswordsMatch();
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                CheckPasswordsMatch();
            }
        }

        private bool _passwordsMatch;
        public bool PasswordsMatch
        {
            get=> _passwordsMatch;
            set
            {
                _passwordsMatch = value;
                OnPropertyChanged(nameof(PasswordsMatch));
            }
        }

        /*public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        private void CheckPasswordsMatch()
        {
            PasswordsMatch = Password == ConfirmPassword;
        }

        //NavigationService Command
        public ICommand GoToSignupPage2Command { get; }

       

        //Implement INotifyPropertyChanged members here
    }
}
