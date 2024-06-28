namespace APBD_9.Repositories;

using APBD_9.Models;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(int clientId);
    Task<Client?> GetClientByPeselAsync(string pesel);
    Task AddClientAsync(Client client);
    Task DeleteClientAsync(Client client);
    Task<bool> SaveChangesAsync();
}