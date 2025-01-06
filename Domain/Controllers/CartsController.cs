using Domain.DTO;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly OrderService _orderService;
        public CartsController(string dalUrl, HttpClientHandler clientHandler)
        {
            _employeeService = new EmployeeService(dalUrl, clientHandler);
            _orderService = new OrderService(dalUrl, clientHandler);

        }
        // POST api/carts
        [HttpPost] // заказать товары из корзины
        public async Task<IActionResult> Post([FromBody] ProductListDto request)
        {
            var employee = await _employeeService.FindFreeStorekeeper();
            var orders = await _orderService.CreateProductOrdersList(request.ClientId, employee, request.Products);
            var response = await _orderService.CreateProductOrder(orders);
            if (response != null)
            {
                return Ok(response);
            }
            else { return BadRequest("Заказы не добавились"); }
        }

    }
}
