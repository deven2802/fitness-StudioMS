using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        //this.BindingContext = new TabbedPageViewModel();
	}

    private async void GoToSettingPageCommand(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingPage));
    }

    /*
    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        bool confirmLogout = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");

        if (confirmLogout)
        {
            // Implement your logout logic here

            // Navigate to LoginPage
            await Shell.Current.GoToAsync(nameof(LoginPage)); // Using shell navigation
        }
    }
    */
}