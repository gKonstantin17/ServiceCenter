using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.Diagnostic_cardDto;
using ORM.Models;

namespace ORM.Controllers
{
    [Route("api/diagnostic_cards")]
    [ApiController]
    public class Diagnostic_cardsController : ControllerBase
    {
        private readonly ApplicationContext _db; 

        public Diagnostic_cardsController(ApplicationContext db)
        { 
            _db = db;
        }
        // GET: api/diagnostic_cards
        [HttpGet]

        public async Task<IEnumerable<Diagnostic_card>> Get()
        {
            return await _db.Diagnostic_card.ToListAsync();
        }

        // GET api/diagnostic_cards/5
        [HttpGet("{id}")]
        public async Task<Diagnostic_card?> Get(int id)
        {
            var result = await _db.Diagnostic_card.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }
        // POST api/diagnostic_cards
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Diagnostic_cardCreateDto value)
        {
            var result = await _db.Diagnostic_card.AddAsync(new Diagnostic_card
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Technique = await _db.Technique.SingleAsync(c => c.Id == value.TechniqueId),
                Desctription = value.Desctription,
                Price = value.Price,
                Deadline = value.Deadline
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/diagnostic_cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] Diagnostic_cardDto value)
        {
            var diagnostic_card = await Get(id);
            if (diagnostic_card == null) return default;

            diagnostic_card.UpdateDate = DateTime.UtcNow;
            if (value.Desctription != null) diagnostic_card.Desctription = value.Desctription;
            if (value.Price != null) diagnostic_card.Price = (int)value.Price;
            if (value.Deadline != null) diagnostic_card.Deadline = (DateTime)value.Deadline;
            var result = _db.Diagnostic_card.Update(diagnostic_card);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE api/diagnostic_cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            var diagnostic_card = await Get(id);
            if (diagnostic_card == null) return default;
            _db.Remove(diagnostic_card);
            await _db.SaveChangesAsync();
            return Ok(diagnostic_card.Id);
        }
    }
}
