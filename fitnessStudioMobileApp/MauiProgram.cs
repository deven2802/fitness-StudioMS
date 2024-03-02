using fitnessStudioMobileApp.Services;
using fitnessStudioMobileApp.ViewModels;
using fitnessStudioMobileApp.Views;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Syncfusion.Maui.Core.Hosting;


namespace fitnessStudioMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("WorkSans-Bold.otf", "WorkSansBold");
                    fonts.AddFont("WorkSans-Light.otf", "WorkSansLight");
                    fonts.AddFont("WorkSans-SemiBold.otf", "WorkSansSemiBold");
                    fonts.AddFont("WorkSans-Medium.otf", "WorkSansMedium");
                });

            //add service in .net maui
            builder.Services.AddTransient<SignupPageViewModel>();

            return builder.Build();
        }
    }
}