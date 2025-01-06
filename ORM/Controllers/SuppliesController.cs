using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.SupplyDto;
using ORM.Models;
namespace ORM.Controllers
{
    [Route("api/supplies")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public SuppliesController(ApplicationContext db)
        {
            _db = db;
        }
        // GET: api/supplies
        [HttpGet]
        public async Task<IEnumerable<Supply>> Get()
        {
            return await _db.Supply.ToListAsync();
        }

        // GET api/supplies/5
        [HttpGet("{id}")]
        public async Task<Supply?> Get(int id)
        {
            var result = await _db.Supply.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST api/supplies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Supply value)
        {
            var result = await _db.Supply.AddAsync(new Supply
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Address = value.Address,
                Email = value.Email,
                Phone = value.Phone,
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/supplies/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] SupplyDto value)
        {
            var supply = await Get(id);
            if (supply == null) return default;

            supply.UpdateDate = DateTime.UtcNow;
            if (value.Address != null) supply.Address = value.Address;
            if (value.Email != null) supply.Email = value.Email;
            if (value.Email != null) supply.Email = value.Email;
            var result =  _db.Supply.Update(supply);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE api/supplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id) 
        {
            var supply = await Get(id);
            if (supply == null) return default;
            _db.Remove(supply);
            await _db.SaveChangesAsync();
            return Ok(supply.Id);
        }
    }
}
