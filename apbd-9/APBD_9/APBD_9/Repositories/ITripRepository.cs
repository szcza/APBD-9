using APBD_9.Models;

namespace APBD_9.Repositories;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllTripsAsync(int page, int pageSize);
    Task<Trip?> GetTripByIdAsync(int tripId);
    Task<int> GetTripsCountAsync();
    Task<bool> SaveChangesAsync();
}