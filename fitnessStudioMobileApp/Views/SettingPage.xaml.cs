using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
		this.BindingContext = new TabbedPageViewModel();
	}


}