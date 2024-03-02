using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MobileApp.Services
{
    public class HttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler()
        {
            var handler = new HttpClientHandler();

            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
            }

            handler.ServerCertificateCustomValidationCallback = (HttpRequestMessage requestMessage, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslErrors) =>
            {
                // Customize your SSL validation logic here
                // For example, for development purposes, you might want to accept any certificate:
                return true; // WARNING: Only use this for testing purposes!
            };

            return handler;
        }
    }
}
