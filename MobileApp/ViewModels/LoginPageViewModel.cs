using CommunityToolkit.Mvvm.Input;
using MobileApp.Views;
using System;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

//using ClassLibrary.Models;
using System.ComponentModel;

namespace MobileApp.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        //show and hide function at register page
        private string _passwordIcon = "hide_password.png";

        public string PasswordIcon
        {
            get => _passwordIcon;
            set
            {
                SetProperty(ref _passwordIcon, value);
            }
        }

        private string _passwordIcon1 = "hide_password.png";

        public string PasswordIcon1
        {
            get => _passwordIcon1;
            set
            {
                SetProperty(ref _passwordIcon1, value);
            }
        }
    }
}
