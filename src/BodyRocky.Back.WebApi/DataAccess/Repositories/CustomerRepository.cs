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
    
    public async Task<int> CountAsync()
    {
        return await _context.Customers.CountAsync();
    }

    public async Task<List<Customer>> GetAllAsync(int skip, int take)
    {
        return await _context.Customers
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid customerID)
    {
        return await _context.Customers.FindAsync(customerID);
    }

    public async Task<Customer> InsertAsync(Customer customer)
    {
        var entityEntry = await _context.Customers.AddAsync(customer);
        var newCustomer = entityEntry.Entity;
        await _context.SaveChangesAsync();
        return newCustomer;
    }

    public async Task DeleteAsync(Guid customerID)
    {
        var customer = await _context.Customers.FindAsync(customerID);
        if (customer is not null)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return customer;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}