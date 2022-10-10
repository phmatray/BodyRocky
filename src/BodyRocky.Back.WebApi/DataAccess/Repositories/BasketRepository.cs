using BodyRocky.Back.WebApi.DataAccess.Entities;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

public sealed class BasketRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public BasketRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Baskets.CountAsync();
    }

    public async Task<List<Basket>> GetAllAsync()
    {
        return await _context.Baskets.ToListAsync();
    }
    
    public async Task<Basket?> GetByIDAsync(Guid basketID)
    {
        return await _context.Baskets.FindAsync(basketID);
    }

    public async Task InsertAsync(Basket basket)
    {
        await _context.Baskets.AddAsync(basket);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}