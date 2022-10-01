﻿using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class ProductRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public ProductRepository(BodyRockyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Entities.Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid productID)
    {
        return await _context.Products.FindAsync(productID);
    }

    public async Task InsertAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid productID)
    {
        var product = await _context.Products.FindAsync(productID);
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}