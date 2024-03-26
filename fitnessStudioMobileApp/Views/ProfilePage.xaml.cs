using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        this.BindingContext = new SignupPageViewModel();
    }

    private async void GoToSettingPageClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SettingPage)}");
    }
}