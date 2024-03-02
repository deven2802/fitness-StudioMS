/*
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MobileApp.Services
{
    public interface IItemService
    {
        Task<List<ItemTable>> GetProducts();
        // Other methods like AddProduct, UpdateProduct, DeleteProduct, etc.
    }

    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ItemService> _logger;
        private const string BaseUrl = "https://192.168.68.128:45455/api/Item"; // Replace with your actual API base URL

        public ItemService(IHttpClientFactory httpClientFactory, ILogger<ItemService> logger, HttpsClientHandlerService handlerService)
        {
            var messageHandler = handlerService.GetPlatformMessageHandler();
            _httpClient = new HttpClient(messageHandler);
            _logger = logger;
        }

        public async Task<List<ItemTable>> GetProducts()
        {
            try
            {
                HttpResponseMessage apiResponse = await _httpClient.GetAsync(BaseUrl);

                if (apiResponse.IsSuccessStatusCode)
                {
                    string response = await apiResponse.Content.ReadAsStringAsync();
                    List<ItemTable> items = JsonConvert.DeserializeObject<List<ItemTable>>(response);
                    return items;
                }
                else
                {
                    _logger.LogError($"GetProducts failed with status code: {apiResponse.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"An error occurred connecting to the API: {ex.Message}");
            }

            return null;
        }

        // Implement other CRUD methods like AddProduct, UpdateProduct, DeleteProduct, etc.
        // Example:
        // public async Task<ItemTable> AddProduct(ItemTable item)
        // {
        //     // Implementation
        // }

    }
}
*/