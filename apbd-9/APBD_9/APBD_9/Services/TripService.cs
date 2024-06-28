using APBD_9.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_9.Repositories;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public async Task<(IEnumerable<Trip>, int)> GetTripsAsync(int page, int pageSize)
    {
        var trips = await _tripRepository.GetAllTripsAsync(page, pageSize);
        var totalTrips = await _tripRepository.GetTripsCountAsync();
        return (trips, totalTrips);
    }
}