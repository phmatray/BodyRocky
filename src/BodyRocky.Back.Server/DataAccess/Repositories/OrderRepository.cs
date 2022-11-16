using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

public sealed class OrderRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public OrderRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Orders.CountAsync();
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIDAsync(Guid orderID)
    {
        return await _context.Orders
            .SingleOrDefaultAsync(order => order.OrderID == orderID);
    }

    public async Task InsertAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid orderID)
    {
        var order = await _context.Orders
            .SingleOrDefaultAsync(order => order.OrderID == orderID);
        
        _context.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}