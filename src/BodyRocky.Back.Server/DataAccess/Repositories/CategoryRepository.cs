using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

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
        return await _context.Categories
            .Include(x => x.ProductCategories)
            .ToListAsync();
    }

    public async Task<List<Category>> GetTop6FeaturedAsync()
    {
        return await _context.Categories
            .Include(x => x.ProductCategories)
            .Where(x => x.IsFeatured)
            .OrderBy(category => category.CategoryID)
            .Take(6)
            .ToListAsync();
    }

    public async Task<Category?> GetByIDAsync(Guid categoryID)
    {
        Category? category = await _context.Categories
            .SingleOrDefaultAsync(x => x.CategoryID == categoryID);
        
        if (category is not null)
        {
            await _context.Entry(category)
                .Collection(x => x.ProductCategories)
                .LoadAsync();
        }
        
        return category;
    }

    public async Task InsertAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid categoryID)
    {
        var category = await _context.Categories
            .SingleOrDefaultAsync(x => x.CategoryID == categoryID);
        
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