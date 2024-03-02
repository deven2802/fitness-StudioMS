using fitnessStudioMobileApp.Services;
using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }

    /*private async void GoToSignup2Clicked(object sender, EventArgs e)
    {
        // Implement your login logic here (if any)

        // Navigate to MainPage
        await Shell.Current.GoToAsync(nameof(SignupPage2)); // Using shell navigation
    }

    private async void BackToLoginCommand(object sender, EventArgs e)
    {
        // Implement your login logic here (if any)

        // Navigate to MainPage
        await Shell.Current.GoToAsync(nameof(LoginPage)); // Using shell navigation
    }*/
}