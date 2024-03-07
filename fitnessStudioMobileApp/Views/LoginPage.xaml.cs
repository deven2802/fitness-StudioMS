using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }


    /*private async void OnForgetPasswordPage(object sender, EventArgs e)
    {
        // Navigate to ForgotPasswordPage
        await Shell.Current.GoToAsync($"{nameof(ForgotPasswordPage)}");
    }*/
}