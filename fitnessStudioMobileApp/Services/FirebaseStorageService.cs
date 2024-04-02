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
using System.Diagnostics;

namespace fitnessStudioMobileApp.Services
{
    public class FirebaseStorageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseStorageUrl;

        public FirebaseStorageService(string firebaseStorageBucket)
        {
            _httpClient = new HttpClient();
            _firebaseStorageUrl = $"gs://fitnessstudioms-b48bf.appspot.com";
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                fileStream.Position = 0; // Reset stream position
                string url = $"https://firebasestorage.googleapis.com/v0/b/fitnessstudioms-b48bf.appspot.com/o?name={Uri.EscapeDataString(fileName)}&uploadType=media";
                HttpContent content = new StreamContent(fileStream);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                string resultContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"Upload response: {resultContent}");

                if (response.IsSuccessStatusCode)
                {
                    var resultObject = JsonConvert.DeserializeObject<FirebaseUploadResult>(resultContent);
                    Debug.WriteLine($"Uploaded File URL: {resultObject?.MediaLink}");
                    return resultObject?.MediaLink;
                }
                else
                {
                    throw new Exception($"Failed to upload file. Status code: {response.StatusCode}, Response: {resultContent}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error uploading file to Firebase Storage: {ex}");
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
