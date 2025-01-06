using Domain.DTO;
using Domain.Repositories;

namespace Domain.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly OrderRepository _orderRepository;

        public EmployeeService(string dalUrl, HttpClientHandler clientHandler)
        {
            _employeeRepository = new EmployeeRepository(dalUrl, clientHandler);
            _orderRepository = new OrderRepository(dalUrl, clientHandler);
        }

        public async Task<EmployeeDto?> FindFreeEmployee(string jobTitle)
        {
            var employees = await _employeeRepository.Get();
            var orders = await _orderRepository.Get();
            var filteredEmployees = employees.Where(c => c.Job_title == jobTitle).ToList();

            if (orders != null && orders.Any())
            {
                var progressOrders = orders.Where(c => c.Status == "Выполняется").ToList();
                if (progressOrders != null && progressOrders.Any())
                {
                    var employeeOrdersCount = filteredEmployees.ToDictionary(e => e.Id, e => progressOrders.Count(o => o.EmployeeId == e.Id));
                    var employeeWithLeastOrders = filteredEmployees
                        .OrderBy(e => employeeOrdersCount.ContainsKey(e.Id) ? employeeOrdersCount[e.Id] : 0)
                        .FirstOrDefault();
                    return employeeWithLeastOrders;
                }
                else
                {
                    return filteredEmployees.FirstOrDefault();
                }
            }
            else
            {
                return filteredEmployees.FirstOrDefault();
            }
        }

        public Task<EmployeeDto?> FindFreeMaster()
        {
            return FindFreeEmployee("Мастер");
        }

        public Task<EmployeeDto?> FindFreeStorekeeper()
        {
            return FindFreeEmployee("Кладовщик");
        }
    }
}
