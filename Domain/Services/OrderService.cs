using Domain.DTO;
using Domain.Repositories;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Domain.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ProductRepository _productRepository;
        private readonly ServiceRepository _serviceRepository;
        private readonly TechniqueRepository _techniqueRepository;
        private readonly ProductService _productService;

        public OrderService(string dalUrl, HttpClientHandler clientHandler)
        {
            _orderRepository = new OrderRepository(dalUrl, clientHandler);
            _employeeRepository = new EmployeeRepository(dalUrl, clientHandler);
            _productRepository = new ProductRepository(dalUrl, clientHandler);
            _serviceRepository = new ServiceRepository(dalUrl, clientHandler);
            _techniqueRepository = new TechniqueRepository(dalUrl, clientHandler);
            _productService = new ProductService(dalUrl, clientHandler);
        }
        public OrderDto CreateTechniqueOrder(int idClient, EmployeeDto employee, int? service)
        {
            var order = new OrderDto
            {
                ClientId = idClient,
                EmployeeId = employee.Id,
                Status = "Выполняется",
                ServiceId = service
            };
            return order;
        }

        public async Task<List<OrderDto>> CreateProductOrdersList(int idClient, EmployeeDto employee, List<ProductBuyDto> products)
        {
            List<OrderDto> orders = new List<OrderDto>();

            foreach (var product in products)
            {
                var order = new OrderDto
                {
                    ClientId = idClient,
                    EmployeeId = employee.Id,
                    Status = "Выполняется",
                    ProductId = product.Id,
                    ProductQty = product.ProductQty
                };
                await _productService.ChangeQty(product, product.ProductQty);
                orders.Add(order);
            }

            return orders;
        }
        public async Task<List<int>?> CreateProductOrder(List<OrderDto> orders)
        {
            List<int> responses = new List<int>();
            foreach (var order in orders)
            {
                var response = await _orderRepository.Post(order);
                if (response == null)
                    return null;
                responses.Add((int)response);
            }
            return responses;
        }
        public async Task<List<OrderDto>> GetOrdersByClientId(int clientId)
        {
            var orders = await _orderRepository.Get();
            var ClientOrders = orders.Where(c => c.ClientId == clientId).ToList();
            return ClientOrders;
        }

        public async Task<List<OrderDetaledDto>> CollectDetaledOrder(List<OrderDto> orders)
        {
            List<OrderDetaledDto> ordersDetaled = new List<OrderDetaledDto>();
            foreach (var order in orders)
            {
                var employee = await _employeeRepository.GetById(order.EmployeeId);
                var product = order.ProductId.HasValue ? await _productRepository.GetById((int)order.ProductId) : null;
                var service = order.ServiceId.HasValue ? await _serviceRepository.GetById((int)order.ServiceId) : null;
                var technique = service != null ? await _techniqueRepository.GetById(service.TechniqueId) : null;
                var orderDetaled = new OrderDetaledDto
                {
                    Order = order,
                    Employee = employee,
                    Product = product,
                    Service = service,
                    Technique = technique,
                };
                ordersDetaled.Add(orderDetaled);
            };
            return ordersDetaled;

        }

    }
}
