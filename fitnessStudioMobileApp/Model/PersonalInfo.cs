using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace fitnessStudioMobileApp.Model
{
    public class PersonalInfo : INotifyPropertyChanged
    {
        #region Fields

        private string? fullName;
        private string? email;
        private string? phoneNumber;
        private string? homeAddress;

        #endregion

        #region Constructor

        public PersonalInfo()
        {

        }

        #endregion

        #region Properties

        public string? FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string? PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string? HomeAddress
        {
            get { return homeAddress; }
            set
            {
                homeAddress = value;
                OnPropertyChanged("HomeAddress");
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
