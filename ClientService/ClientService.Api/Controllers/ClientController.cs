using ClientService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientAppService _clientService;

        public ClientController(ClientAppService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("getBy{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ClientService.Domain.Entities.Client client)
        {
            await _clientService.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        [HttpPut("update{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClientService.Domain.Entities.Client client)
        {
            if (id != client.Id) return BadRequest();
            await _clientService.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
