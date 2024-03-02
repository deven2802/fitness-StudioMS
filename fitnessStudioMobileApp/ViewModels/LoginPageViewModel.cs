using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using fitnessStudioMobileApp.Views;

namespace fitnessStudioMobileApp.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        /*private async void OnLogin()
        {
            //Implement the login logic here
            //After login, navigate to Home Page
            await Shell.Current.GoToAsync(nameof(MainPage));
        }*/

        private async void OnLogin()
        {
            try
            {
                // Implement the login logic here

                // Navigate to MainPage
                await Shell.Current.GoToAsync("MainPage"); // Use the route name
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
