using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.ProductDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/products")]
    [ApiController]
    

    public class ProductsController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ProductsController(ApplicationContext db)
        {
            _db = db;
        }
        // GET: api/products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _db.Product.ToListAsync();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            var result = await _db.Product.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto value)
        {
            var result = await _db.Product.AddAsync(new Product
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Ordered_product = await _db.Ordered_product.SingleAsync(c => c.Id == value.Ordered_productId),
                Title = value.Title,
                Price = value.Price,
                Quantity = value.Quantity,
                ImgLink = value.ImgLink
        }); ;
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] ProductDto value)
        {
            var product = await Get(id);
            if (product == null) return default;

            product.UpdateDate = DateTime.UtcNow;
            if (value.Title != null) product.Title = value.Title;
            if (value.Price != null) product.Price = (int)value.Price;
            if (value.Quantity != null) product.Quantity = (int)value.Quantity;
            if (value.ImgLink != null) product.ImgLink = value.ImgLink;
            _db.Product.Update(product);
            await _db.SaveChangesAsync();
            return Ok(product.Id);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            var product = await Get(id);
            if (product == null) return default;
            _db.Remove(product);
            await _db.SaveChangesAsync();
            return Ok(product.Id);
        }
    }
}
