using Domain.DTO;
using Domain.Repositories;
using System.Text.RegularExpressions;

namespace Domain.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(string dalUrl, HttpClientHandler clientHandler)
        {
            _clientRepository = new ClientRepository(dalUrl, clientHandler);
        }
        public bool ValidateClient(ClientDto client)
        {
            string emailPattern = @"^[a-zA-Z0-9\.\-_]{3,25}@[a-z]{3,8}\.[a-z]{2,8}$";
            string phonePattern = @"^\+?[0-9]{1,3}9[0-9]{9}$";
            string fullnamePattern = @"^[А-ЯA-Z][а-яa-z]+\s[А-ЯA-Z][а-яa-z]+\s[А-ЯA-Z][а-яa-z]+$";
            string passwordPattern = @"^[a-zA-Z0-9]{3,20}$";
            if (string.IsNullOrEmpty(client.Fullname) ||
                string.IsNullOrEmpty(client.Phone) ||
                string.IsNullOrEmpty(client.Email) ||
                string.IsNullOrEmpty(client.Password))
                return false;
            if (!Regex.IsMatch(client.Email, emailPattern))
                return false;
            if (!Regex.IsMatch(client.Phone, phonePattern))
                return false;
            if (!Regex.IsMatch(client.Fullname, fullnamePattern))
                return false;
            if (!Regex.IsMatch(client.Password, passwordPattern))
                return false;
            return true;
        }
        
        public async Task<bool> CheckExistClient(ClientDto client)
        {
            var clients = await _clientRepository.Get();
            var existClient = clients.Where(c => c.Email == client.Email).SingleOrDefault();
            return existClient != null;
        }
    }
}
