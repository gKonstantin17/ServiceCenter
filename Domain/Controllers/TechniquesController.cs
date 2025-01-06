using Domain.DTO;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Domain.Controllers
{
    [Route("api/techniques")]
    [ApiController]
    public class TechniquesController : ControllerBase
    {
        private readonly TechniqueRepository _techniqueRepository;
        private readonly OrderRepository _orderRepository;
        private readonly EmployeeService _employeeService;
        private readonly OrderService _orderService;
        private readonly ServiceService _serviceService;

        public TechniquesController(string dalUrl, HttpClientHandler clientHandler)
        {
            _techniqueRepository = new TechniqueRepository(dalUrl, clientHandler);
            _orderRepository = new OrderRepository(dalUrl, clientHandler);
            _employeeService = new EmployeeService(dalUrl, clientHandler);
            _orderService = new OrderService(dalUrl, clientHandler);
            _serviceService = new ServiceService(dalUrl, clientHandler);

        }
        // POST api/techniques
        [HttpPost]
        // оформление заказа на ремонт техники
        public async Task<IActionResult> Post([FromBody] TechniqueOrderDto request)
        {
            var technique = new TechniqueDto
            {
                Title = request.Title,
                Description = request.Description,
                Typetech = request.Typetech,
            };
            var addedTechnique = await _techniqueRepository.Post(technique);
            if (addedTechnique == null)
                return BadRequest("Техника не добавилась");

            var employee = await _employeeService.FindFreeMaster();
            var service = await _serviceService.SetService(addedTechnique);
            if (service == null)
                return BadRequest("Услуга не добавилась");

            var order = _orderService.CreateTechniqueOrder(request.ClientId, employee, service);
            var response = await _orderRepository.Post(order);
            if (response == null)
                return BadRequest("Заказ не добавился");
            else return Ok();

            
        }
    }
}
