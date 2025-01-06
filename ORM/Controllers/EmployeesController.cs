using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORM.DTO.EmployeeDto;
using ORM.Models;


namespace ORM.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationContext _db; 

        public EmployeesController(ApplicationContext db)
        { 
            _db = db;
        }
        // GET: api/employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _db.Employee.ToListAsync();
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public async Task<Employee?> Get(int id)
        {
            var result = await _db.Employee.SingleOrDefaultAsync(o => o.Id == id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return default;
            }
            return result;
        }

        // POST api/employees
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee value)
        {
            var result = await _db.Employee.AddAsync(new Employee
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Fullname = value.Fullname,
                Phone = value.Phone,
                Job_title = value.Job_title,
            });
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult?> Put(int id, [FromBody] EmployeeDto value)
        {
            var employee = await Get(id);
            if (employee == null) return default;

            employee.UpdateDate = DateTime.UtcNow;
            if (value.Fullname != null) employee.Fullname = value.Fullname;
            if (value.Phone != null) employee.Phone = value.Phone;
            if (value.Job_title != null) employee.Job_title = value.Job_title;
            var result = _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return Ok(result.Entity.Id);
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult?> Delete(int id)
        {
            var employee = await Get(id);
            if (employee == null) return default;
            _db.Remove(employee);
            await _db.SaveChangesAsync();
            return Ok(employee.Id);
        }
    }
}
