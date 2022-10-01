using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class CustomerRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public CustomerRepository(BodyRockyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid customerID)
    {
        return await _context.Customers.FindAsync(customerID);
    }

    public async Task InsertAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid customerID)
    {
        var customer = await _context.Customers.FindAsync(customerID);
        _context.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}