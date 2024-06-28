using APBD_9.Context;
using APBD_9.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_9.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly Apbd9Context _context;

    public ClientRepository(Apbd9Context context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(int clientId)
    {
        return await _context.Clients
            .Where(c => c.IdClient == clientId).SingleAsync();
    }

    public async Task<Client?> GetClientByPeselAsync(string pesel)
    {
        return await _context.Clients.FirstOrDefaultAsync(c => c.Pesel == pesel);
    }

    public async Task AddClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task DeleteClientAsync(Client client)
    {
        _context.Clients.Remove(client);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}