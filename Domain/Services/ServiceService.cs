using Domain.DTO;
using Domain.Repositories;

namespace Domain.Services
{
    public class ServiceService
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceService(string dalUrl, HttpClientHandler clientHandler)
        {
            _serviceRepository = new ServiceRepository(dalUrl, clientHandler);
        }

        public async Task<int?> SetService(int? idTechnique)
        {
            if (idTechnique == null) { return null; }
            var service = new ServiceDto
            {
                Title = "Диагностика",
                Price = 0,
                TechniqueId = (int)idTechnique
            };
            var response = await _serviceRepository.Post(service);
            if (response != null)
            {
                return response;
            }
            else { return null; }
        }
    }
}
