using fitnessStudioMobileApp.ViewModels;
using fitnessStudioMobileApp.Model;
using fitnessStudioMobileApp.Services;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace fitnessStudioMobileApp.Views;

public partial class UploadReceiptPage : ContentPage
{
	public UploadReceiptPage()
	{
		InitializeComponent();
        this.BindingContext = new TabbedPageViewModel();
    }

    //UploadImage uploadImage { get; set; }

    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        try
        {
            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                {DevicePlatform.iOS, new[] {"public.image"} },
                {DevicePlatform.Android, new[] {"image/*"} },
            });

            var options = new PickOptions
            {
                PickerTitle = "Please select a file",
                FileTypes = customFileType,
            };

            var result = await FilePicker.PickAsync(options);
            if(result != null)
            {
                Stream fileStream = await result.OpenReadAsync();

                var viewModel = (TabbedPageViewModel)this.BindingContext;
                if (viewModel != null)
                {
                    viewModel.FileName = result.FileName; // Update the ViewModel with the selected file name
                    await viewModel.UploadFile(fileStream, result.FileName);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error picking file: {ex.Message}");
        }
        /*
        var img = await uploadImage.OpenMediaPickerAsync();

        var imagefile = await uploadImage.Upload(img);

        Image_Upload.Source = ImageSource.FromStream(() =>
            uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64)));
        */
    }
}