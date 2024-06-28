using APBD_9.Models;

public interface IClientService
{
    Task<bool> DeleteClientAsync(int clientId);
    Task<bool> AssignClientToTripAsync(Client client, int tripId, DateTime? paymentDate);
}