using System.Globalization;
using Color = Microsoft.Maui.Graphics.Color;
using System.Drawing;
using fitnessStudioMobileApp.ViewModels;
using fitnessStudioMobileApp.Model;
using fitnessStudioMobileApp.Behavior;
using fitnessStudioMobileApp.Converter;
using Syncfusion.Maui.Scheduler;

namespace fitnessStudioMobileApp.Views;

public partial class BookingPage : ContentPage
{
    //private string timeSlot = string.Empty;

    public BookingPage()
    {
        InitializeComponent();
        this.BindingContext = new TabbedPageViewModel();
        // <summary>
        // The time slot string is used to handle while book an appointment. While select the time slot then time slot variable value will be updates with respective tapped time slot.
        // It is used to reset the time slot.
        // </summary>


        // <summary>
        // Initializes a new instance of the <see cref="Year" /> class.
        // </summary>
        /*
    #if MACCATALYST
                this.border.IsVisible = true;
                this.border.Stroke = Color.FromArgb("#E6E6E6");
                this.InitializeCalendar(this.appointmentBooking1, this.deskTop);
    #elif !ANDROID && !IOS
                this.frame.IsVisible = true;
                this.frame.BorderColor = Color.FromArgb("#E6E6E6");
                this.InitializeCalendar(this.appointmentBooking, this.deskTop);
    #else
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                this.border.IsVisible = true;
                this.border.Stroke = Color.FromArgb("#E6E6E6");
                this.InitializeCalendar(this.appointmentBooking1, this.deskTop);
            }
            else
            {
                this.InitializeCalendar(this.mobileAppointmentBooking, this.mobile);
            }
    #endif
        }

        private async void OnBookingButtonClicked(object sender, EventArgs e)
        {
            // Navigate to ForgotPasswordPage
            await Shell.Current.GoToAsync(nameof(SlotBookingPage));
        }

        /// <summary>
        /// Initialize the calendar.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="parent">Parent view of calendar control.</param>
        private void InitializeCalendar(Syncfusion.Maui.Calendar.SfCalendar calendar, Grid parent)
        {
            parent.IsVisible = true;
            calendar.MaximumDate = DateTime.Now.Date.AddMonths(3);
            calendar.SelectedDate = DateTime.Now.Date;
        }

        /*
        /// <summary>
        /// Method to update the selected date changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">Event arguments.</param>
        private void AppointmentBooking_SelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
        {
    #if MACCATALYST
                this.UpdateDateSelection(this.appointmentBooking1, this.label1, this.flexLayout1);
    #elif !ANDROID && !IOS
                this.UpdateDateSelection(this.appointmentBooking, this.label, this.flexLayout);
    #else
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                this.UpdateDateSelection(this.appointmentBooking1, this.label1, this.flexLayout1);
            }
            else
            {
                this.UpdateDateSelection(this.mobileAppointmentBooking, this.mobileLabel, this.mobileFlexLayout);
            }
    #endif
            this.timeSlot = string.Empty;
        }
        */
        /*
        /// <summary>
        /// Update the UI based on calendar selected date.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="textLabel">Selected date text label.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private void UpdateDateSelection(Syncfusion.Maui.Calendar.SfCalendar calendar, Label textLabel, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                return;
            }

            DateTime dateTime = calendar.SelectedDate.Value;
            string dayText = dateTime.ToString("MMMM" + " " + dateTime.Day.ToString() + ", " + dateTime.ToString("yyyy"), CultureInfo.CurrentUICulture);
            textLabel.Text = dayText;
            //// The time slot is empty then no need to reset the time slot.
            if (this.timeSlot == string.Empty)
            {
                return;
            }

            foreach (Button child in buttonLayout.Children)
            {
                Button button = (Button)child;
                button.TextColor = Colors.Black;
                button.Background = Colors.White;
            }
        }

        /*
        /// <summary>
        /// Method to Book an Appointment based on the selected date and selected time slot.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">Event arguments.</param>
        private void AppointmentanBooking(object sender, EventArgs e)
        {
    #if MACCATALYST
                this.BookAppointment(this.appointmentBooking1, this.flexLayout1);
    #elif !ANDROID && !IOS
                this.BookAppointment(this.appointmentBooking, this.flexLayout);
    #else
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                this.BookAppointment(this.appointmentBooking1, this.flexLayout1);
            }
            else
            {
                this.BookAppointment(this.mobileAppointmentBooking, this.mobileFlexLayout);
            }
    #endif
        }
        */
        /*
        /// <summary>
        /// Book the appointment on selected date and time slot.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private void BookAppointment(Syncfusion.Maui.Calendar.SfCalendar calendar, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a date to book an appointment ", "Ok");
                return;
            }

            if (this.timeSlot == string.Empty)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a time to book an appointment ", "Ok");
                return;
            }

            DateTime dateTime = calendar.SelectedDate.Value;
            string dayText = dateTime.ToString("MMMM" + " " + dateTime.Day.ToString() + ", " + dateTime.ToString("yyyy"), CultureInfo.CurrentUICulture);
            string text = "Appointment booked for " + dayText + " " + timeSlot;
            Application.Current?.MainPage?.DisplayAlert("Confirmation", text, "Ok");
            calendar.SelectedDate = DateTime.Now.Date;
            calendar.DisplayDate = DateTime.Now.Date;
            this.timeSlot = string.Empty;
            foreach (Button child in buttonLayout.Children)
            {
                Button button = (Button)child;
                button.TextColor = Colors.Black;
                button.Background = Colors.White;
            }
        }

        // <summary>
        // Method to update the slot booking.
        // </summary>
        // <param name="sender">The object.</param>
        // <param name="e">Event arguments.</param>
        /*private void SlotBooking_Changed(object sender, EventArgs e)
        {
    #if MACCATALYST
                this.UpdateTimeSlotSelection(this.appointmentBooking1, (Button)sender, this.flexLayout1);
    #elif !ANDROID && !IOS
                this.UpdateTimeSlotSelection(this.appointmentBooking, (Button)sender, this.flexLayout);
    #else
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                this.UpdateTimeSlotSelection(this.appointmentBooking1, (Button)sender, this.flexLayout1);
            }
            else
            {
                this.UpdateTimeSlotSelection(this.mobileAppointmentBooking, (Button)sender, this.mobileFlexLayout);
            }
    #endif
        }*/
        /*
        /// <summary>
        /// Update the UI based on selected time slot.
        /// </summary>
        /// <param name="calendar">Calendar instance.</param>
        /// <param name="selectedButton">Selected time slot button.</param>
        /// <param name="buttonLayout">Time slot button layout.</param>
        private void UpdateTimeSlotSelection(Syncfusion.Maui.Calendar.SfCalendar calendar, Button selectedButton, FlexLayout buttonLayout)
        {
            if (calendar.SelectedDate == null)
            {
                Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a date to book an appointment ", "Ok");
                return;
            }

            foreach (Button child in buttonLayout.Children)
            {
                Button unPressedbutton = (Button)child;
                if (unPressedbutton == selectedButton)
                {
                    selectedButton.TextColor = Colors.White;
                    selectedButton.Background = Color.FromArgb("#6200EE");
                    timeSlot = selectedButton.Text;
                    continue;
                }

                unPressedbutton.TextColor = Colors.Black;
                unPressedbutton.Background = Colors.White;
            }
        */
    }

    //navigate the class schedule from the booking page to the slot booking page
    private async void OnClassTapped(object sender, SchedulerTappedEventArgs e)
    {
        // Navigate to SlotBookingPage, passing the selectedAppointment as a parameter
        // Adjust navigation based on your app's navigation structure
        await Shell.Current.GoToAsync(nameof(SlotBookingPage), true, new Dictionary<string, object>());
    }
}

