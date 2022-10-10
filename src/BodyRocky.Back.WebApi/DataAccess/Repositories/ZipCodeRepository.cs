using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class ZipCodeRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public ZipCodeRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.ZipCodes.CountAsync();
    }

    public async Task<List<ZipCode>> GetAllAsync()
    {
        return await _context.ZipCodes.ToListAsync();
    }

    public async Task<ZipCode?> GetByIDAsync(Guid zipCodeID)
    {
        return await _context.ZipCodes.FindAsync(zipCodeID);
    }

    public async Task InsertAsync(ZipCode zipCode)
    {
        await _context.ZipCodes.AddAsync(zipCode);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid zipCodeID)
    {
        var zipCode = await _context.ZipCodes.FindAsync(zipCodeID);
        _context.Remove(zipCode);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ZipCode zipCode)
    {
        _context.Entry(zipCode).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}