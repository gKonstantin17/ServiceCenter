using Domain.DTO;
using Newtonsoft.Json;

namespace Domain.Repositories
{
    public class EmployeeRepository
    {
        private readonly string? _dalUrl;
        private readonly HttpClient _httpClient;
        public EmployeeRepository(string dalUrl, HttpClientHandler clientHandler)
        {
            _dalUrl = dalUrl;
            _httpClient = new HttpClient(clientHandler);
        }
        public async Task<List<EmployeeDto>> Get()
        {
            var response = await _httpClient.GetAsync($"{_dalUrl}/employees");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);
            return employees;
        }
        public async Task<EmployeeDto?> GetById(int id)
        {

            var response = await _httpClient.GetAsync($"{_dalUrl}/employees/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeDto>(content);
            return employee;
        }
        public async Task<int?> Post(EmployeeDto employee)
        {
            var addedEmployee = await _httpClient.PostAsJsonAsync($"{_dalUrl}/employees", employee);
            if (addedEmployee.IsSuccessStatusCode)
            {
                var createdEmployee = await addedEmployee.Content.ReadFromJsonAsync<int>();
                return createdEmployee;
            }
            return null;

        }
        public async Task<int?> Put(EmployeeDto employee)
        {

            var response = await _httpClient.PutAsJsonAsync($"{_dalUrl}/employees/{employee.Id}", employee);
            if (response.IsSuccessStatusCode)
            {
                var changedEmployee = await response.Content.ReadFromJsonAsync<int>();
                return changedEmployee;
            }
            return null;
        }
        public async Task<int?> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_dalUrl}/employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                var deletedEmployee = await response.Content.ReadFromJsonAsync<int>();
                return deletedEmployee;
            }
            return null;

        }
    }
}
