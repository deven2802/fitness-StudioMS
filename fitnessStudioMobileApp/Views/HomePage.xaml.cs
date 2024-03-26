using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		this.BindingContext = new TabbedPageViewModel();
	}
}