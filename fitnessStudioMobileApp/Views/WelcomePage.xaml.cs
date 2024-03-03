namespace fitnessStudioMobileApp.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}

    private async void OnGetStartedClicked(object sender, EventArgs e)
    {
        var signupPage = new SignupPage();


        await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
    }

}