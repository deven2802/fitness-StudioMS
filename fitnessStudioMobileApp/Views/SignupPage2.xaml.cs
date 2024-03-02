namespace fitnessStudioMobileApp.Views;

public partial class SignupPage2 : ContentPage
{
	public SignupPage2()
	{
		InitializeComponent();
	}

    private async void RegisterOnClicked(object sender, EventArgs e)
    {
        // Navigate to ForgotPasswordPage
        await Shell.Current.GoToAsync($"//main");
        await Shell.Current.GoToAsync($"{nameof(HomePage)}");
    }
}