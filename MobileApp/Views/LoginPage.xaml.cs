using MobileApp.ViewModels;

namespace MobileApp.Views;

public partial class LoginPage : ContentPage
{
    private bool _isPasswordVisible = false;
    public string PasswordIcon { get; set; } = "hide_password.png";

    public LoginPage()
	{
		InitializeComponent();
	}

    private void TogglePasswordVisibility(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        passwordEntry.IsPassword = !_isPasswordVisible;

        ((LoginPageViewModel)this.BindingContext).PasswordIcon = _isPasswordVisible ? "show_password.png" : "hide_password.png";
        OnPropertyChanged(nameof(PasswordIcon));
    }
}