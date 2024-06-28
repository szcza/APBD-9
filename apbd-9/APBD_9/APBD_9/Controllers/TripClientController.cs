using APBD_9.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TripClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public TripClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // POST: api/trips/{idTrip}/clients
    [HttpPost("trips/{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] ClientDto clientDto)
    {
        var client = new Client
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            Email = clientDto.Email,
            Telephone = clientDto.Telephone,
            Pesel = clientDto.Pesel
        };

        var result = await _clientService.AssignClientToTripAsync(client, idTrip, clientDto.PaymentDate);
        if (!result)
        {
            return BadRequest("Failed to assign client to trip.");
        }

        return Ok();
    }
}

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string Pesel { get; set; }
    public DateTime? PaymentDate { get; set; }
}