using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
        this.BindingContext = this;
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Implement your login logic here (if any)

        // Navigate to MainPage
        await Shell.Current.GoToAsync($"//main");
        await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        //await Shell.Current.GoToAsync(nameof(HomePage)); // Using shell navigation
    }

    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Navigate to ForgotPasswordPage
        await Shell.Current.GoToAsync(nameof(ForgotPasswordPage));
    }

    private async void BackToSignupCommand(object sender, EventArgs e)
    {
        // Navigate to ForgotPasswordPage
        await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}