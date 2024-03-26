using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessStudioMobileApp.Services
{
    public class FirebaseAuthService
    {
        public string webApiKey = "AIzaSyBbQIxyNOIAkyA-A5Wvuz5TrSsXJtOGvLc";

        public async Task<string> GetFirebaseTokenAsync()
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                // Replace with your Firebase Authentication logic
                var authResult = await authProvider.SignInWithEmailAndPasswordAsync("user@example.com", "password");
                // var token = await authResult.User.GetIdTokenAsync(false);
                //return token;
                string token = authResult.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Congratulation!", "User Registered successfully", "OK");
                return token;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error obtaining Firebase token: {ex.Message}");
                return null;
            }
        }

    }
}
