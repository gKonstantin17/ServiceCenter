using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class Diagnostic_cardRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public Diagnostic_cardRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<Diagnostic_cardDto>?> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/diagnostic_cards");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var dcards = JsonConvert.DeserializeObject<List<Diagnostic_cardDto>>(content);
            return dcards;
        }
        public async Task<Diagnostic_cardDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/diagnostic_cards/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var dcard = JsonConvert.DeserializeObject<Diagnostic_cardDto>(content);
            return dcard;
        }
        public async Task<int?> Post(Diagnostic_cardDto dcard)
        {
            var addedDcard = await _httpClient.PostAsJsonAsync($"{_dalUrl}/diagnostic_cards", dcard);
            if (addedDcard.IsSuccessStatusCode)
            {
                var createdDcard = await addedDcard.Content.ReadFromJsonAsync<int>();
                return createdDcard;
            }
            return null;

        }
        public async Task<int?> Put(Diagnostic_cardDto dcard)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/diagnostic_cards/{dcard.Id}", dcard);
            if (response.IsSuccessStatusCode)
            {
                var changedDcard = await response.Content.ReadFromJsonAsync<int>();
                return changedDcard;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_dalUrl}/diagnostic_cards/{id}");
            if (response.IsSuccessStatusCode)
            {
                var deletedDcard = await response.Content.ReadFromJsonAsync<int>();
                return deletedDcard;
            }
            return null;

        }
    }
}
