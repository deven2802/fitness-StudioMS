using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using fitnessStudioMobileApp.Views;
using fitnessStudioMobileApp.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;


namespace fitnessStudioMobileApp.ViewModels
{
    public partial class TabbedPageViewModel: ObservableObject
    {
        //navigate to settingPage
        public ICommand GoToSettingPageCommand => new Command(async () => await NavigateToSettingPage());

        private async Task NavigateToSettingPage()
        {
            await Shell.Current.GoToAsync($"{nameof(SettingPage)}");
        }


        private async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            bool confirmLogout = await Shell.Current.DisplayAlert("Log Out", "Are you sure you want to log out?", "Confirm", "Cancel");

            if (confirmLogout)
            {
                //Navigate to login Page
                await Shell.Current.GoToAsync(nameof(LoginPage));
            }
        }

        #region Fields

        private ObservableCollection<AnnouncementInfo>? announcementInfo;
        private ObservableCollection<AnnouncementInfo>? announcementInfo1;

        #endregion

        #region Constructor

        public TabbedPageViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<AnnouncementInfo>? AnnouncementInfo
        {
            get { return announcementInfo; }
            set { this.announcementInfo = value; }
        }

        public ObservableCollection<AnnouncementInfo>? AnnouncementInfo1
        {
            get { return announcementInfo1; }
            set { this.announcementInfo1 = value;}
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            AnnouncementInfoRespository announcementinfo = new();
            announcementInfo = announcementinfo.GetAnnouncementInfo();
            announcementInfo1 = announcementinfo.GetAnnouncementInfo1();
        }

        #endregion
    }
}
