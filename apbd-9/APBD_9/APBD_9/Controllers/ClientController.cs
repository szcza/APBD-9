using APBD_9.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // DELETE: api/clients/{idClient}
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var result = await _clientService.DeleteClientAsync(idClient);
        if (!result)
        {
            return BadRequest("Cannot delete client which is not exist or with assigned trips.");
        }

        return NoContent();
    }
}