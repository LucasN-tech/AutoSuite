using System.Collections.Generic;
using System.Threading.Tasks;
using ClientService.Application.Services;
using ClientService.Domain.Entities;
using ClientService.Domain.Repositories;
using Moq;
using Xunit;

namespace ClientService.Tests
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly ClientAppService _clientService;

        public ClientServiceTests()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _clientService = new ClientAppService(_clientRepositoryMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsClient()
        {
            var client = new Client { Id = 1, Name = "Test" };
            _clientRepositoryMock.Setup(r => r.GetClientByIdAsync(1)).ReturnsAsync(client);

            var result = await _clientService.GetByIdAsync(1);

            Assert.Equal(client, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllClients()
        {
            var clients = new List<Client> { new Client { Id = 1 }, new Client { Id = 2 } };
            _clientRepositoryMock.Setup(r => r.GetAllClientsAsync()).ReturnsAsync(clients);

            var result = await _clientService.GetAllAsync();

            Assert.Equal(2, ((List<Client>)result).Count);
        }

        [Fact]
        public async Task AddAsync_CallsRepository()
        {
            var client = new Client { Id = 1 };

            await _clientService.AddAsync(client);

            _clientRepositoryMock.Verify(r => r.AddClientAsync(client), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_CallsRepository()
        {
            var client = new Client { Id = 1 };

            await _clientService.UpdateAsync(client);

            _clientRepositoryMock.Verify(r => r.UpdateClientAsync(client), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_CallsRepository()
        {
            await _clientService.DeleteAsync(1);

            _clientRepositoryMock.Verify(r => r.DeleteClientAsync(1), Times.Once);
        }
    }
}
