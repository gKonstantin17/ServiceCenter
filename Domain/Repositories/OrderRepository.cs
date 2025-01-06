using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class OrderRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public OrderRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<OrderDto>?> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/orders");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderDto>>(content);
            return orders;
        }
        public async Task<OrderDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/orders/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<OrderDto>(content);
            return order;
        }

        public async Task<int?> Post(OrderDto order)
        {
            var addedOrder = await _httpClient.PostAsJsonAsync($"{_dalUrl}/orders", order);
            if (addedOrder.IsSuccessStatusCode)
            {
                var createdOrder = await addedOrder.Content.ReadFromJsonAsync<int>();
                return createdOrder;
            }
            return null;

        }
        public async Task<int?> Put(OrderDto order)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/orders/{order.Id}", order);
            if (response.IsSuccessStatusCode)
            {
                var changedOrder = await response.Content.ReadFromJsonAsync<int>();
                return changedOrder;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var addedOrder = await _httpClient.DeleteAsync($"{_dalUrl}/orders/{id}");
            if (addedOrder.IsSuccessStatusCode)
            {
                var createdOrder = await addedOrder.Content.ReadFromJsonAsync<int>();
                return createdOrder;
            }
            return null;

        }
    }
}
