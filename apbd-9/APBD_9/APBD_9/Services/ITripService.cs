using APBD_9.Models;

public interface ITripService
{
    Task<(IEnumerable<Trip>, int)> GetTripsAsync(int page, int pageSize);
}