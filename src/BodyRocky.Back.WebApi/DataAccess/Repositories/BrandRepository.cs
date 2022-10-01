using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class BrandRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public BrandRepository(BodyRockyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }

    public async Task<Brand?> GetByIdAsync(Guid brandID)
    {
        return await _context.Brands.FindAsync(brandID);
    }

    public async Task InsertAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid brandID)
    {
        var brand = await _context.Adresses.FindAsync(brandID);
        _context.Remove(brand);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Address brand)
    {
        _context.Entry(brand).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}