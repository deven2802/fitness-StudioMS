using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using fitnessStudioMobileApp.Model;

namespace fitnessStudioMobileApp.Model
{
    public class AnnouncementInfoRespository
    {
        #region Constructor

        public AnnouncementInfoRespository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<AnnouncementInfo> GetAnnouncementInfo()
        {
            var categoryInfo = new ObservableCollection<AnnouncementInfo>();
            for (int i = 0; i < AnnouncementDetail.Length; i++)
            {
                var info = new AnnouncementInfo() { AnnouncementDetail = AnnouncementDetail[i] };

                if (i == 9)
                    info.AnnouncementImage = "profile.png";
                else
                    info.AnnouncementImage = "password.png";

                categoryInfo.Add(info);
            }
            return categoryInfo;
        }

        internal ObservableCollection<AnnouncementInfo> GetAnnouncementInfo1()
        {
            var categoryInfo = new ObservableCollection<AnnouncementInfo>();

            for (int i = 0; i < AnnouncementDetail1.Length; i++)
            {
                var info = new AnnouncementInfo() { AnnouncementDetail = AnnouncementDetail1[i] };

                if (i == 9)
                    info.AnnouncementImage = "home.png";
                else
                    info.AnnouncementImage = "schedule.png";

                categoryInfo.Add(info);
            }
            return categoryInfo;
        }

        #endregion

        #region CategoryInfo

        readonly string[] AnnouncementDetail = new string[]
        {
            "Announcement display here shuiashasiuh",
            "Announcement display here2",
            "Announcement display here3",
            "Announcement display here4",
            "Announcement display here5",
            "Announcement display here6",
            "Announcement display here7",
            "Announcement display here9",
        };

        readonly string[] AnnouncementDetail1 = new string[]
        {
            "Announcement1",
            "Announcement2",
            "Announcement3",
            "Announcement4",
            "Announcement5",
            "Announcement6",
            "Announcement7",
            "Announcement8",
            "Announcement9",
        };

        #endregion
    }
}
