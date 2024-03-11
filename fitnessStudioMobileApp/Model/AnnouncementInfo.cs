using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace fitnessStudioMobileApp.Model
{
    public class AnnouncementInfo : INotifyPropertyChanged
    {
        #region Fields

        private string? announcementImage;
        private string? announcementDetail;

        #endregion

        #region Constructor
        
        public AnnouncementInfo()
        {

        }
        #endregion

        #region Properties

        public string? AnnouncementDetail
        {
            get { return announcementDetail; }
            set
            {
                announcementDetail = value;
                OnPropertyChanged("AnnouncementDetail");
            }
        }

        public string? AnnouncementImage
        {
            get { return announcementImage; }
            set
            {
                announcementImage = value;
                OnPropertyChanged("AnnouncementImage");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
