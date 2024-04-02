using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
		this.BindingContext = new SignupPageViewModel();
	}

    /*
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (this.BindingContext as SignupPageViewModel)?.LoadUserProfile();
    }
    */
}