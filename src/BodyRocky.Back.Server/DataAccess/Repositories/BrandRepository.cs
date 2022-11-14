using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

public sealed class BrandRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public BrandRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Brands.CountAsync();
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brands
            .Include(x => x.Products)
            .ToListAsync();
    }

    public async Task<Brand?> GetByIDAsync(Guid brandID)
    {
        Brand? brand = await _context.Brands
            .SingleOrDefaultAsync(x => x.BrandID == brandID);
        
        if (brand is not null)
        {
            await _context.Entry(brand)
                .Collection(x => x.Products)
                .LoadAsync();
        }
        
        return brand;
    }

    public async Task InsertAsync(Brand brand)
    {
        await _context.Brands.AddAsync(brand);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid brandID)
    {
        var brand = await _context.Brands
            .SingleOrDefaultAsync(x => x.BrandID == brandID);
        
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