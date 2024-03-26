using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class AnnouncementPage : ContentPage
{
	public AnnouncementPage()
	{
		InitializeComponent();
		this.BindingContext = new TabbedPageViewModel();
	}
}