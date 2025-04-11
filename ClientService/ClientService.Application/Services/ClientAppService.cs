using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientService.Domain.Entities;
using ClientService.Domain.Repositories;

namespace ClientService.Application.Services
{
    public class ClientAppService
    {
        private readonly IClientRepository _clientRepository;

        public ClientAppService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Client> GetByIdAsync(int id) => _clientRepository.GetClientByIdAsync(id);
        public Task<IEnumerable<Client>> GetAllAsync() => _clientRepository.GetAllClientsAsync();
        public Task AddAsync(Client client) => _clientRepository.AddClientAsync(client);
        public Task UpdateAsync(Client client) => _clientRepository.UpdateClientAsync(client);
        public Task DeleteAsync(int id) => _clientRepository.DeleteClientAsync(id);
    }
}
