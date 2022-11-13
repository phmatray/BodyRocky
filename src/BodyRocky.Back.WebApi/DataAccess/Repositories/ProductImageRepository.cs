using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class ProductImageRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public ProductImageRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.ProductImages.CountAsync();
    }

    public async Task<List<ProductImage>> GetAllAsync()
    {
        return await _context.ProductImages.ToListAsync();
    }

    public async Task<ProductImage?> GetByIDAsync(Guid productImageID)
    {
        return await _context.ProductImages
            .SingleOrDefaultAsync(productImage => productImage.ProductImageID == productImageID);
    }

    public async Task InsertAsync(ProductImage productImage)
    {
        await _context.ProductImages.AddAsync(productImage);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid productImageID)
    {
        var productImage = await _context.ProductImages
            .SingleOrDefaultAsync(productImage => productImage.ProductImageID == productImageID);
        
        _context.Remove(productImage);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductImage productImage)
    {
        _context.Entry(productImage).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}