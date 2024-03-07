using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }

    private async void OnForgotPasswordPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ForgotPasswordPage)}");
    }
}