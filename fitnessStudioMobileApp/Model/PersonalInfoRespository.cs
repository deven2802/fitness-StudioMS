using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using fitnessStudioMobileApp.Model;

namespace fitnessStudioMobileApp.Model
{
    public class PersonalInfoRespository
    {
        #region Constructor

        public PersonalInfoRespository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<PersonalInfo> GetPersonalInfo()
        {
            var personalInfo = new ObservableCollection<PersonalInfo>();

            for (int i = 0; i < FullName.Length; i++)
            {
                var info = new PersonalInfo()
                {
                    FullName = FullName[i],
                    Email = Email[i],
                    PhoneNumber = PhoneNumber[i],
                    HomeAddress = HomeAddress[i],
                };
                personalInfo.Add(info);
            }
            return personalInfo;
        }

        #endregion

        #region PersonalInfo

        readonly string[] FullName = new string[]
        {
            "Alice Wong Li Li"
        };

        readonly string[] Email = new string[]
        {
            "example@gmail.com",
        };

        readonly string[] PhoneNumber = new string[]
        {
            "0123456789",
        };

        readonly string[] HomeAddress = new string[]
        {
            "Jalan Larkin, example address",
        };
        #endregion
    }
}
