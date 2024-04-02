using fitnessStudioMobileApp.Model;
using System.Globalization;

namespace fitnessStudioMobileApp.Views;

public partial class SlotBookingPage : ContentPage
{
    private List<string> bookedSlots = new List<string>();
    private string timeSlot = string.Empty;

    public SlotBookingPage()
    {
        InitializeComponent();
    }

    private void SlotBooking_Changed(object sender, EventArgs e)
    {
        Button selectedButton = (Button)sender;
        timeSlot = selectedButton.Text;

        if (bookedSlots.Contains(timeSlot))
        {
            DisplayAlert("Slot Unavailable", "This slot is already booked. Please choose another.", "OK");
        }
        else
        {
            // Code to book the slot
            BookAppointment(timeSlot);
        }
    }

    private async void BookAppointment(string slot)
    {


        // Mock delay to simulate booking process
        await Task.Delay(100);

        // Add slot to booked slots list
        bookedSlots.Add(slot);

        await DisplayAlert("Confirmation", $"Appointment booked for {slot}", "OK");

     //   Preferences.Set("selectedSlot", selectedClass.ClassTime);

        // Optionally, reset the UI or navigate to another page
    }


    /*
	private async void BookAppointment(Syncfusion.Maui.Calendar.SfCalendar calendar, FlexLayout buttonLayout)
	{
        if (this.timeSlot == string.Empty)
        {
            Application.Current?.MainPage?.DisplayAlert("Alert !", "Please select a time to book an appointment ", "Ok");
            return;
        }

        DateTime dateTime = calendar.SelectedDate.Value;
        string dayText = dateTime.ToString("MMMM" + " " + dateTime.Day.ToString() + ", " + dateTime.ToString("yyyy"), CultureInfo.CurrentUICulture);
        string text = "Appointment booked for " + dayText + " " + timeSlot;
        popup.Message = text;
        popup.Show();

        await Task.Delay(1000);
        popup.IsOpen = false;

        var doctorInfo = this.BindingContext as DoctorInfo;
        doctorInfo.AppointmentTime = Convert.ToDateTime(dayText + " " + timeSlot); ;
        App.Appointments.Appointments.Add(doctorInfo);

        App.Current.MainPage = new NavigationPage();
        App.Current.MainPage.Navigation.PushAsync(new AppShell());
    }
    */
}
