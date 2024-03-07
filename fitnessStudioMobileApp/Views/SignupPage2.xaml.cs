using fitnessStudioMobileApp.ViewModels;
using Syncfusion.Maui.DataForm;

namespace fitnessStudioMobileApp.Views;

public partial class SignupPage2 : ContentPage
{
	public SignupPage2()
	{
		InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }

    /*private async void RegisterOnClicked(object sender, EventArgs e)
    {
        // Navigate to ForgotPasswordPage
        await Shell.Current.GoToAsync($"//main");
        await Shell.Current.GoToAsync($"{nameof(HomePage)}");
    }*/
}