/*
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MobileApp.Services
{
    public interface IAccountService
    {
        Task<UsersTable> Login(string email, string password);
        Task<UsersTable> RegisterUser(UsersTable user);
        // Other methods like Register, ForgotPassword, etc.
    }


    // Other using directives

    public class UserService : IAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;
        private const string BaseUrl = "https://192.168.202.102:45457/api/Account";

        public UserService(IHttpClientFactory httpClientFactory, ILogger<UserService> logger, HttpsClientHandlerService handlerService)
        {
            var messageHandler = handlerService.GetPlatformMessageHandler();
            _httpClient = new HttpClient(messageHandler);
            _logger = logger;
        }

        public async Task<UsersTable> Login(string email, string password)
        {
            var loginRequest = new { Email = email, Password = password };
            string jsonRequest = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string url = $"{BaseUrl}/Login";

            try
            {
                HttpResponseMessage apiResponse = await _httpClient.PostAsync(url, content);

                if (apiResponse.IsSuccessStatusCode)
                {
                    string response = await apiResponse.Content.ReadAsStringAsync();
                    UsersTable user = JsonConvert.DeserializeObject<UsersTable>(response);
                    return user;
                }
                else
                {
                    _logger.LogError($"Login failed with status code: {apiResponse.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occurred connecting to the API: {ex.Message}");
            }

            return null;
        }

        public async Task<UsersTable> RegisterUser(UsersTable user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}/Register", content);

            if (response.IsSuccessStatusCode)
            {
                var resultJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UsersTable>(resultJson);
            }

            // Handle error cases
            return null;
        }
        
    }

    // Other methods like Register, ForgotPassword, etc.
}

*/