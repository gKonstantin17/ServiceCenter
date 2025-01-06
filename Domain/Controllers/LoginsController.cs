using Domain.DTO;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [Route("api/logins")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ClientRepository _clientRepository;
        public LoginsController(string dalUrl, HttpClientHandler clientHandler)
        {
            _clientRepository = new ClientRepository(dalUrl, clientHandler);
        }
        // POST api/logins
        [HttpPost] // авторизация
        public async Task<IActionResult> Post([FromBody] ClientCheckDto request)
        {
            var users = await _clientRepository.Get();
            var user = users.Where(c => c.Email == request.Email 
            && c.Password == request.Password).SingleOrDefault();
            if (user != null)
            {
                var response = new
                {
                    id = user.Id,
                };
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
