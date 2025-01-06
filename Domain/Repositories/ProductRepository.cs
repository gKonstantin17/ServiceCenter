using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text;
using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class ProductRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public ProductRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<ProductDto>?> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/products");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductDto>>(content);
            return products;
        }
        public async Task<ProductDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/products/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(content);
            return product;
        }
        public async Task<int?> Put(ProductDto product)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/products/{product.Id}", product);
            if (response.IsSuccessStatusCode)
            {
                var changedProduct = await response.Content.ReadFromJsonAsync<int>();
                return changedProduct;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_dalUrl}/products/{id}");
            if (response.IsSuccessStatusCode)
            {
                var deletedProduct = await response.Content.ReadFromJsonAsync<int>();
                return deletedProduct;
            }
            return null;

        }

    }
}
