using APBD_9.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    // GET: api/trips
    [HttpGet]
    public async Task<ActionResult> GetTrips([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var (trips, totalTrips) = await _tripService.GetTripsAsync(page, pageSize);

        var response = new
        {
            pageNum = page,
            pageSize = pageSize,
            allPages = (int)System.Math.Ceiling(totalTrips / (double)pageSize),
            trips = trips.Select(t => new
            {
                t.Name,
                t.Description,
                t.DateFrom,
                t.DateTo,
                t.MaxPeople,
                Countries = t.IdCountries.Select(c => new { c.Name }),
                Clients = t.ClientTrips.Select(ct => new { ct.IdClientNavigation.FirstName, ct.IdClientNavigation.LastName })
            })
        };

        return Ok(response);
    }
}