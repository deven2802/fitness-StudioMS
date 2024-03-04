using Foundation;
using UIKit;
using Firebase.Core;

namespace fitnessStudioMobileApp
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Firebase.Core.App.Configure();

            // Your other initialization code

            return base.FinishedLaunching(app, options);
        }

    }
}