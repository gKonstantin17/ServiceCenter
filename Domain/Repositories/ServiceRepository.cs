using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class ServiceRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public ServiceRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<ServiceDto>?> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/services");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<List<ServiceDto>>(content);
            return services;
        }
        public async Task<ServiceDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/services/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var service = JsonConvert.DeserializeObject<ServiceDto>(content);
            return service;
        }
        public async Task<int?> Post(ServiceDto service)
        {
            
                var addedService = await _httpClient.PostAsJsonAsync($"{_dalUrl}/services", service);
                if (addedService.IsSuccessStatusCode)
                {
                    var createdService = await addedService.Content.ReadFromJsonAsync<int>();
                    return createdService;
                }
                return null;
        }
        public async Task<int?> Put(ServiceDto service)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/services/{service.Id}", service);
            if (response.IsSuccessStatusCode)
            {
                var changedService = await response.Content.ReadFromJsonAsync<int>();
                return changedService;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_dalUrl}/services/{id}");
            if (response.IsSuccessStatusCode)
            {
                var deletedService = await response.Content.ReadFromJsonAsync<int>();
                return deletedService;
            }
            return null;

        }

    }
}
