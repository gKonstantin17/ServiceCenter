using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.OrderDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public OrdersController(ApplicationContext db) { 
            _db = db;
        }
       

        // GET: api/orders
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _db.Order.ToListAsync();
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<Order?> Get(int id) 
        {
            var result = await _db.Order.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderCreateDto value) 
        {
            
            var result = await _db.Order.AddAsync(new Order
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Client = await _db.Client.SingleAsync(c => c.Id == value.ClientId),
                Employee = await _db.Employee.SingleAsync(c => c.Id == value.EmployeeId),
                Product = value.ProductId.HasValue ? await _db.Product.SingleAsync(c => c.Id == value.ProductId) : null,
                Service = value.ServiceId.HasValue ? await _db.Service.SingleAsync(c => c.Id == value.ServiceId) : null,
                Status = value.Status,
                ProductQty = value.ProductQty.HasValue ? value.ProductQty.Value : null
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
            
        }

        // PUT: api/orders/5 
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] OrderDto value)
        {
            var order = await Get(id);
            if (order == null) return default;

            order.UpdateDate = DateTime.UtcNow;
            if (value.Deadline != null) order.Deadline = (DateTime)value.Deadline;
            if (value.Status != null) order.Status = value.Status;
            if (value.ProductQty != null) order.ProductQty = value.ProductQty;
            var result = _db.Order.Update(order);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id) 
        {
            var order = await Get(id);
            if (order == null) return default;
            _db.Remove(order);
            await _db.SaveChangesAsync();
            return Ok(order.Id);
        }
    }
}
