using System;
using Acr.UserDialogs;

namespace MobileApp.Services;

public partial class AlertService
{
    public enum Duration
    {
        Short,
        Long
    }



   // public partial void ShowToast(string message, Duration duration = Duration.Short);


public void ShowLoading(string title = null)
    {
#if ANDROID
        UserDialogs.Instance.ShowLoading();
#endif
#if IOS
            UserDialogs.Instance.ShowLoading();
#endif
    }

    public void HideLoading()
    {
#if ANDROID
        UserDialogs.Instance.HideLoading();
#endif
#if IOS
            UserDialogs.Instance.HideLoading();
#endif
    }
}

