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
using fitnessStudioMobileApp.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Firebase.Storage;
using Firebase.Auth;
using Firebase.Database;
using Syncfusion.Maui.Scheduler;
using System.Diagnostics;
using Microsoft.Maui.Storage;


namespace fitnessStudioMobileApp.ViewModels
{
    public partial class TabbedPageViewModel: ObservableObject, INotifyPropertyChanged
    {   
        //navigate to settingPage
        public ICommand GoToSettingPageCommand { get; }

        private async Task GoToSettingPageAsync()
        {
            // Assuming you're using Shell navigation
            await Shell.Current.GoToAsync(nameof(SettingPage));
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

        /*
        UploadImage uploadImage { get; set; }

        private async void OnUploadImageClicked(object sender, EventArgs e)
        {
            var img = await uploadImage.OpenMediaPickerAsync();

            var imagefile = await uploadImage.Upload(img);

            //Image_Upload.Source = ImageSource.FromStream(() => 
            uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64));
        }
        */

        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        private readonly FirebaseStorageService _firebaseStorageService;

        public async Task UploadFile(Stream fileStream, string _fileName)
        {
            try
            {
               // string firebaseToken = await GetFirebaseTokenAsync(); // Implement this method to get the Firebase token
                string imageUrl = await _firebaseStorageService.UploadFileAsync(fileStream, _fileName);

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("Success", "Payment Receipt Uploaded successfully!", "OK");
                    });
                }
                else
                {
                    // Handle the failure case, e.g., by showing an error message
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Failed to upload the payment receipt.", "OK");
                    });
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error uploading file: {ex.Message}");
            }
        }

        private string _statusMessage = "Select a file to upload: ";
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }


        //display the announcement info in the home page starts//
        //display the personal information in the setting page starts//
        #region Fields

        private ObservableCollection<AnnouncementInfo>? announcementInfo;
        private ObservableCollection<AnnouncementInfo>? announcementInfo1;

        //personal information
        private ObservableCollection<PersonalInfo>? personalInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TabbedPageViewModel" /> class.
        /// </summary>
        public TabbedPageViewModel()
        {
            //page navigation
            GoToSettingPageCommand = new Command(async () => await GoToSettingPageAsync());

            ///uploadImage = new UploadImage();

            GenerateSource();

            //part of the code for class scheduler
            this.Events = new ObservableCollection<SchedulerAppointment>();
            this.IntializeClasses();
            this.DisplayDate = DateTime.Now.Date.AddHours(8).AddMinutes(50);
            this.MinDateTime = DateTime.Now.Date.AddMonths(-3);
            this.MaxDateTime = DateTime.Now.AddMonths(3);
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

        //personal information
        public ObservableCollection<PersonalInfo>? PersonalInfo
        {
            get { return personalInfo; }
            set { this.personalInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            //announcement respository
            AnnouncementInfoRespository announcementinfo = new();
            announcementInfo = announcementinfo.GetAnnouncementInfo();
            announcementInfo1 = announcementinfo.GetAnnouncementInfo1();

            //personalInfo respository
            PersonalInfoRespository personalinfo = new();
            personalInfo = personalinfo.GetPersonalInfo();

            //class respository
            ClassInfoRespository classinfo = new();
            classInfo = classinfo.GetClassInfo();
        }

        #endregion
        //display the announcement in the home page ends

        //display the classes in the home page starts
        #region Fields

        private ObservableCollection<ClassInfo>? classInfo;

        #endregion

        #region Properties

        public ObservableCollection<ClassInfo>? ClassInfo
        {
            get { return classInfo; }
            set { this.classInfo = value; }
        }

        #endregion
        //display the classes in the home page ends

        //display the class scheduler in the booking page starts
        #region Fields

        /// <summary>
        /// team management
        /// </summary>
        private List<string> subjects;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<SchedulerAppointment> Events { get; set; }

        /// <summary>
        /// Gets or sets the schedule display date.
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets the schedule min date time.
        /// </summary>
        public DateTime MinDateTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule max date time.
        /// </summary>
        public DateTime MaxDateTime { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Method to initialize the appointments.
        /// </summary>
        private void IntializeClasses()
        {
            ObservableCollection<DateTime> WorkWeekDays = new ObservableCollection<DateTime>();
            ObservableCollection<string> WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            ObservableCollection<DateTime> NonWorkingDays = new ObservableCollection<DateTime>();

            ObservableCollection<Brush> colorCollection = this.GetColorCollection();


            Random ran = new();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime startMonth = new(today.Year, today.Month - 1, 1, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);

            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }

            for (int i = 0; i < WorkWeekDays.Count; i++)
            {
                DateTime date = WorkWeekDays[i];
                int count = ran.Next(2, 4);
                for (int index = 0; index < count; index++)
                {
                    int startIndex = 8 + (index * 3) + ran.Next(0, 2);
                    DateTime startDate = date.AddHours(startIndex);
                    this.Events.Add(new SchedulerAppointment()
                    {
                        StartTime = startDate,
                        EndTime = startDate.AddHours(1),
                        Background = colorCollection[ran.Next(0, colorCollection.Count)],
                        Subject = WorkWeekSubjects[ran.Next(0, WorkWeekSubjects.Count)]
                    });
                }
            }

            //// Adding Span appointments
            SchedulerAppointment classes = new SchedulerAppointment();
            classes.StartTime = today.Date.AddDays(1);
            classes.EndTime = today.Date.AddDays(8);
            classes.Subject = WorkWeekSubjects[0];
            classes.Background = colorCollection[0];

            this.Events.Add(classes);
        }

        private ObservableCollection<Brush> GetColorCollection()
        {
            ObservableCollection<Brush> colors = new ObservableCollection<Brush>
            {
                new SolidColorBrush(Color.FromArgb("#FF8B1FA9")),
                new SolidColorBrush(Color.FromArgb("#FFD20100")),
                new SolidColorBrush(Color.FromArgb("#FFFC571D")),
                new SolidColorBrush(Color.FromArgb("#FF36B37B")),
                new SolidColorBrush(Color.FromArgb("#FF3D4FB5")),
                new SolidColorBrush(Color.FromArgb("#FFE47C73")),
                new SolidColorBrush(Color.FromArgb("#FF636363")),
                new SolidColorBrush(Color.FromArgb("#FF85461E")),
                new SolidColorBrush(Color.FromArgb("#FF0F8644")),
                new SolidColorBrush(Color.FromArgb("#FF01A1EF"))
            };

            return colors;
        }
    }

        #endregion


        //display the class scheduler in the booking page ends
}
