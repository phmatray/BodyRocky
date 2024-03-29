﻿using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

public sealed class ProductRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public ProductRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
    
    public async Task<List<Product>> GetTop4FeaturedAsync()
    {
        return await _context.Products
            .Where(p => p.IsFeatured)
            .OrderBy(p => p.ProductName)
            .Take(4)
            .ToListAsync();
    }

    public async Task<List<Product>> GetTop8RecommendedAsync()
    {
        return await _context.Products
            .Where(p => !p.IsFeatured)
            .OrderBy(p => p.ProductName)
            .Take(8)
            .ToListAsync();
    }

    public async Task<Product?> GetByIDAsync(Guid productID)
    {
        return await _context.Products
            .SingleOrDefaultAsync(p => p.ProductID == productID);
    }

    public async Task InsertAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid productID)
    {
        var product = await _context.Products
            .SingleOrDefaultAsync(p => p.ProductID == productID);
        
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