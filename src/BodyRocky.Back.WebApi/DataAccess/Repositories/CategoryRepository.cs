using BodyRocky.Back.WebApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess.Repositories;

public sealed class CategoryRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public CategoryRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Categories.CountAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<List<Category>> GetTop5FeaturedAsync()
    {
        return await _context.Categories
            .Where(x => x.IsFeatured)
            .Take(5)
            .ToListAsync();
    }

    public async Task<Category?> GetByIDAsync(Guid categoryID)
    {
        return await _context.Categories.FindAsync(categoryID);
    }

    public async Task InsertAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid categoryID)
    {
        var category = await _context.Categories.FindAsync(categoryID);
        _context.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}