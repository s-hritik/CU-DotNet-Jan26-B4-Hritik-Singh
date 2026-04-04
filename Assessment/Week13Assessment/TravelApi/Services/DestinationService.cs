using System;
using Microsoft.AspNetCore.Http.HttpResults;
using TravelApi.Models;
using TravelApi.Repository;


namespace TravelApi.Services;

public class DestinationService : IDestinationService
{
    private readonly IDestinationRepository _repo;

    public DestinationService(IDestinationRepository repo)
    {
        _repo = repo;
    }

    public async Task AddAsync(Destination destination)
    {
        await _repo.AddAsync(destination);
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _repo.GetByIdAsync(id);
        if (value == null) throw new ArgumentException("value Cannot be null");
        await _repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        var destination = await _repo.GetAllAsync();
        if (destination == null) throw new ArgumentException("List is Empty");
        return destination;
    }

    public async Task<Destination> GetByIdAsync(int id)
    {
        var value = await _repo.GetByIdAsync(id);
        if (value == null) throw new ArgumentException("Id is not Not Available");
        return value;
    }

    public async Task UpdateAsync(Destination destination)
    {
        var value = await _repo.GetByIdAsync(destination.Id);
        if (value == null) throw new ArgumentException("Destination not found");
        await _repo.UpdateAsync(destination);
    }
}
