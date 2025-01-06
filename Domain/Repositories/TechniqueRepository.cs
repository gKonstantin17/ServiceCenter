using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class TechniqueRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public TechniqueRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<TechniqueDto>?> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/techniques");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var techniques = JsonConvert.DeserializeObject<List<TechniqueDto>>(content);
            return techniques;
        }
        public async Task<TechniqueDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/techniques/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var technique = JsonConvert.DeserializeObject<TechniqueDto>(content);
            return technique;
        }
        public async Task<int?> Post(TechniqueDto technique)
        {
            var addedTechnique = await _httpClient.PostAsJsonAsync($"{_dalUrl}/techniques", technique);
            if (addedTechnique.IsSuccessStatusCode)
            {
                var idTechnique = await addedTechnique.Content.ReadFromJsonAsync<int>();
                
                return idTechnique;
            }
            return null;

        }
        public async Task<int?> Put(TechniqueDto technique)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/techniques/{technique.Id}", technique);
            if (response.IsSuccessStatusCode)
            {
                var changedTechnique = await response.Content.ReadFromJsonAsync<int>();
                return changedTechnique;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_dalUrl}/techniques/{id}");
            if (response.IsSuccessStatusCode)
            {
                var deletedTechnique = await response.Content.ReadFromJsonAsync<int>();
                return deletedTechnique;
            }
            return null;

        }
    }
}
