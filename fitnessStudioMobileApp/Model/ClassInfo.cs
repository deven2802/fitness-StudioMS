using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace fitnessStudioMobileApp.Model
{
    public class ClassInfo : INotifyPropertyChanged 
    {
        #region Fields

        private string? className;
        private string? classTime;
        private string? coachName;

        #endregion

        #region Constructor

        public ClassInfo()
        {

        }

        #endregion

        #region Properties

        public string? ClassName
        {
            get { return className; }
            set
            {
                className = value;
                OnPropertyChanged("ClassName");
            }
        }

        public string? ClassTime
        {
            get { return classTime; }
            set
            {
                classTime = value;
                OnPropertyChanged("ClassTime");
            }
        }

        public string? CoachName
        {
            get { return coachName; }
            set
            {
                coachName = value;
                OnPropertyChanged("CoachName");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
