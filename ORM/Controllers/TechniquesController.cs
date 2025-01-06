using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.TechniqueDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/techniques")]
    [ApiController]
    public class TechniquesController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public TechniquesController(ApplicationContext db)
        { 
            _db = db;
        }
        // GET: api/techniques
        [HttpGet]
        public async Task<IEnumerable<Technique>> Get() 
        {
            return await _db.Technique.ToListAsync();
        }

        // GET api/techniques/5
        [HttpGet("{id}")]
        public async Task<Technique?> Get(int id) 
        {
            var result = await _db.Technique.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST api/techniques
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Technique value)
        {
            var result = await _db.Technique.AddAsync(new Technique
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Title = value.Title,
                Typetech = value.Typetech,
                Description = value.Description
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/techniques/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] TechniqueDto value)
        {
            var technique = await Get(id);
            if (technique == null) return default;

            technique.UpdateDate = DateTime.UtcNow;
            if (value.Title != null) technique.Title = value.Title;
            if (value.Typetech != null) technique.Typetech = value.Typetech;
            if (value.Description != null) technique.Description = value.Description;
            var result = _db.Technique.Update(technique);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE api/techniques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            var technique = await Get(id);
            if (technique == null) return default;
            _db.Remove(technique);
            await _db.SaveChangesAsync();
            return Ok(technique.Id);
        }
    }
}
