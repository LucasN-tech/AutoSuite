using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientService.Domain.Entities;

namespace ClientService.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetClientByIdAsync(int id);
        Task<Client> GetClientByCnpjAsync(string cnpj);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int id);
    }
}
