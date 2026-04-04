using System;
using Microsoft.EntityFrameworkCore;
using TravelApi.Data;
using TravelApi.Models;

namespace TravelApi.Repository;

public class DestinationRepository : IDestinationRepository
{
    private readonly AppDbContext _context;
    public DestinationRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Destination destination)
    {
        await _context.Destinations.AddAsync(destination);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _context.Destinations.FindAsync(id);
        if (value != null)
        {
            _context.Destinations.Remove(value);
            await _context.SaveChangesAsync();
        }

    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await _context.Destinations.ToListAsync();
    }

    public async Task<Destination> GetByIdAsync(int id)
    {
        return await _context.Destinations.FindAsync(id);
    }

    public async Task UpdateAsync(Destination destination)
    {
        _context.ChangeTracker.Clear();
        _context.Destinations.Update(destination);
        await _context.SaveChangesAsync();
    }
}
