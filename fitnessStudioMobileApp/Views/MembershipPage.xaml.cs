using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp.Views;

public partial class MembershipPage : ContentPage
{
	public MembershipPage()
	{
		InitializeComponent();
		this.BindingContext = new TabbedPageViewModel();
	}
}