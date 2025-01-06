using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.ServiceDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public ServicesController(ApplicationContext db)
        {
            _db = db;
        }
        // GET: api/services
        [HttpGet]
        
        public async Task<IEnumerable<Service>> Get()
        {
            return await _db.Service.ToListAsync();
        }

        // GET api/services/5
        [HttpGet("{id}")]
        public async Task<Service?> Get(int id) 
        {
            var result = await _db.Service.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }
        // POST api/services
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceCreateDto value)
        {
                var result = await _db.Service.AddAsync(new Service
                {
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    Technique = await _db.Technique.SingleAsync(c => c.Id == value.TechniqueId),
                    Title = value.Title,
                    Price = value.Price,
                });
                await _db.SaveChangesAsync();
                return Ok(result.Entity.Id);
        }

        // PUT api/services/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] ServiceDto value)
        {
            
            var service = await Get(id);
            if (service == null) return default;

            service.UpdateDate = DateTime.UtcNow;
            if (value.Title != null) service.Title = value.Title;
            if (value.Price != null) service.Price = (int)value.Price;
            var result = _db.Service.Update(service);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
           
        }

        // DELETE api/services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id) 
        {
            var service = await Get(id);
            if (service == null) return default;
            _db.Remove(service);
            await _db.SaveChangesAsync();
            return Ok(service.Id);
        }
    }
}
