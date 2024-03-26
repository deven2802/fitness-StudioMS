using fitnessStudioMobileApp.Views;

namespace fitnessStudioMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
            Routing.RegisterRoute(nameof(SignupPage2), typeof(SignupPage2));
            Routing.RegisterRoute(nameof(AnnouncementPage), typeof(AnnouncementPage));
            Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
            Routing.RegisterRoute(nameof(MembershipPage), typeof(MembershipPage));
            Routing.RegisterRoute(nameof(SlotBookingPage), typeof(SlotBookingPage));
            Routing.RegisterRoute(nameof(SettingPage), typeof(SettingPage));
            Routing.RegisterRoute(nameof(UploadReceiptPage), typeof(UploadReceiptPage));
            Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

        }
    }
}