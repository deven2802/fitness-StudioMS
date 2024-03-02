using fitnessStudioMobileApp.ViewModels;

namespace fitnessStudioMobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzEzNDY5MkAzMjM0MmUzMDJlMzBjaitORGZwcmNPTjdEODdRSXA2MWtZOFFRYkh0Y0lFWHV4SmpwZkgrdHBjPQ==");

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }
    }
}