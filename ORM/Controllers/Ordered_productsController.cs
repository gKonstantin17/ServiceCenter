using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.Ordered_productDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/ordered_products")]
    [ApiController]
    public class Ordered_productsController : ControllerBase
    {
        private readonly ApplicationContext _db;
        public Ordered_productsController(ApplicationContext db)
        {
            _db = db;
        }
        // GET: api/ordered_products
        [HttpGet]
        public async Task<IEnumerable<Ordered_product>> Get()
        {
            return await _db.Ordered_product.ToListAsync();
        }

        // GET api/ordered_products/5
        [HttpGet("{id}")]
        public async Task<Ordered_product?> Get(int id) 
        {
            var result = await _db.Ordered_product.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST api/ordered_products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ordered_productCreateDto value)
        {
            var result = await _db.Ordered_product.AddAsync(new Ordered_product
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Supply = await _db.Supply.SingleAsync(c => c.Id == value.SupplyId),
                Title = value.Title,
                Price = value.Price,
                Quantity = value.Quantity,
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/ordered_products/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] Ordered_productDto value)
        {
            var ordered_product = await Get(id);
            if (ordered_product == null) return default;

            ordered_product.UpdateDate = DateTime.UtcNow;
            if (value.Title != null) ordered_product.Title = value.Title;
            if (value.Price != null) ordered_product.Price = (int)value.Price;
            if (value.Quantity != null) ordered_product.Quantity = (int)value.Quantity;
            var result = _db.Ordered_product.Update(ordered_product);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE api/ordered_products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id) 
        {
            var ordered_product = await Get(id);
            if (ordered_product == null) return default;
            _db.Remove(ordered_product);
            await _db.SaveChangesAsync();
            return Ok(ordered_product.Id);
        }
    }
}
