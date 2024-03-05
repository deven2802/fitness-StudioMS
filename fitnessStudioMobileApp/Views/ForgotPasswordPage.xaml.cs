using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class ForgotPasswordPage : ContentPage
{
	public ForgotPasswordPage()
	{
		InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }
}