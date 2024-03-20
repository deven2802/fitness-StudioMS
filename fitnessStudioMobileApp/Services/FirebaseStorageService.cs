using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace fitnessStudioMobileApp.Services
{
    public class FirebaseStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseStorageUrl;

        public FirebaseStorageService(string firebaseStorageBucket)
        {
            _httpClient = new HttpClient();
            _firebaseStorageUrl = $"https://firebasestorage.googleapis.com/v0/b/gs://fitnessstudioms-b48bf.appspot.com/o";
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string firebaseToken = null)
        {
            try
            {

                string url = $"{_firebaseStorageUrl}?name={Uri.EscapeDataString(fileName)}&uploadType=media";

                // Optionally add an Authorization header if your Firebase Storage requires authentication
                // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", firebaseToken);

                HttpContent content = new StreamContent(fileStream);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                string resultContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Assuming the response contains the download URL or similar
                    // You might need to adjust this part based on your requirements and the actual response structure
                    var resultObject = JsonConvert.DeserializeObject<FirebaseUploadResult>(resultContent);
                    return resultObject?.MediaLink; // Return the direct link to the uploaded file
                }
                else
                {
                    throw new Exception($"Failed to upload file. Status code: {response.StatusCode}, Response: {resultContent}");
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                Console.WriteLine($"Error uploading file to Firebase Storage: {ex}");
                return null;
            }
        }

        private class FirebaseUploadResult
        {
            // Adjust these properties according to the actual JSON response structure of Firebase Storage
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("bucket")]
            public string Bucket { get; set; }

            [JsonProperty("mediaLink")]
            public string MediaLink { get; set; }
        }
    }
}
