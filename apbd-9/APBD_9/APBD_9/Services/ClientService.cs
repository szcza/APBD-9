using APBD_9.Models;
using System;
using APBD_9.Repositories;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly ITripRepository _tripRepository;

    public ClientService(IClientRepository clientRepository, ITripRepository tripRepository)
    {
        _clientRepository = clientRepository;
        _tripRepository = tripRepository;
    }

    public async Task<bool> DeleteClientAsync(int clientId)
    {
        var client = await _clientRepository.GetClientByIdAsync(clientId);
        if (client == null || client.ClientTrips.Any())
        {
            return false;
        }

        _clientRepository.DeleteClientAsync(client);
        return await _clientRepository.SaveChangesAsync();
    }

    public async Task<bool> AssignClientToTripAsync(Client client, int tripId, DateTime? paymentDate)
    {
        var trip = await _tripRepository.GetTripByIdAsync(tripId);
        if (trip == null || trip.DateFrom <= DateTime.Now)
        {
            return false;
        }

        var existingClient = await _clientRepository.GetClientByPeselAsync(client.Pesel);
        if (existingClient != null)
        {
            var existingClientTrip = existingClient.ClientTrips.FirstOrDefault(ct => ct.IdTrip == tripId);
            if (existingClientTrip != null)
            {
                return false;
            }
            client = existingClient;
        }

        var clientTrip = new ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = tripId,
            RegisteredAt = DateTime.Now,
            PaymentDate = paymentDate
        };

        if (existingClient == null)
        {
            await _clientRepository.AddClientAsync(client);
        }

        client.ClientTrips.Add(clientTrip);
        return await _clientRepository.SaveChangesAsync();
    }
}