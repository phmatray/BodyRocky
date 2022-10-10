using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class AddressRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public AddressRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Addresses.CountAsync();
    }

    public async Task<List<Address>> GetAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }

    public async Task<Address?> GetByIDAsync(Guid addressID)
    {
        return await _context.Addresses.FindAsync(addressID);
    }

    public async Task InsertAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid addressID)
    {
        var address = await _context.Addresses.FindAsync(addressID);
        _context.Remove(address);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Address address)
    {
        _context.Entry(address).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}