using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using fitnessStudioMobileApp.Model;

namespace fitnessStudioMobileApp.Model
{
    public class ClassInfoRespository
    {
        #region Constructor

        public ClassInfoRespository()
        {

        }

        #endregion

        #region Properties

        internal ObservableCollection<ClassInfo> GetClassInfo()
        {
            var classInfo = new ObservableCollection<ClassInfo>();

            for (int i = 0; i < ClassNames.Length; i++)
            {
                var info = new ClassInfo()
                {
                    ClassName = ClassNames[i],
                    ClassTime = ClassTime[i],
                    CoachName = CoachNames[i],
                };
                classInfo.Add(info);
            }
            return classInfo;
        }

        #endregion

        #region ClassInfo

        readonly string[] ClassNames = new string[]
        {
             "Yoga",
             "Aesthetic",
             "Yoga2",
             "Yoga3",
        };

        readonly string[] CoachNames = new string[]
        {
             "Alice",
             "Lily",
             "Alfred",
             "Shaun",
        };

        readonly string[] ClassTime = new string[]
        {
             "10am - 12pm",
             "10am - 12pm",
             "10am - 12pm",
             "10am - 12pm",
        };
        #endregion
    }
}
