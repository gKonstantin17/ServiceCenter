using Domain.DTO;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Domain.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        public OrdersController(string dalUrl, HttpClientHandler clientHandler)
        {
            _orderRepository = new OrderRepository(dalUrl, clientHandler);
            _orderService = new OrderService(dalUrl, clientHandler);
            _productService = new ProductService(dalUrl, clientHandler);
        }

        // GET api/orders/5
        [HttpGet("{id}")]  // найти заказы клиента
        public async Task<ActionResult<List<OrderDetaledDto>?>> GetByClient(int id)
        {
            var orders = await _orderService.GetOrdersByClientId(id);
            var ordersDetaled = await _orderService.CollectDetaledOrder(orders);
            return ordersDetaled;
        }
        [HttpDelete("{id}")] // отменить заказ
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order != null)
            {
                if (order.ProductId != null)
                {
                    await _productService.ReturnQtyInProduct((int)order.ProductId, (int)order.ProductQty);
                }
                await _orderRepository.Delete(id);
                return Ok();
            }
            else
            {
                return BadRequest("Заказ не найден");
            }

            
        }
    }
}
