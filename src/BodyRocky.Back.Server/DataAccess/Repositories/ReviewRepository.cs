using BodyRocky.Back.Server.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

public sealed class ReviewRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public ReviewRepository(BodyRockyDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Reviews.CountAsync();
    }

    public async Task<List<Review>> GetAllAsync()
    {
        return await _context.Reviews.ToListAsync();
    }

    public async Task<Review?> GetByIDAsync(Guid reviewID)
    {
        return await _context.Reviews
            .SingleOrDefaultAsync(review => review.ReviewID == reviewID);
    }

    public async Task InsertAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid reviewID)
    {
        var review = await _context.Reviews
            .SingleOrDefaultAsync(review => review.ReviewID == reviewID);
        
        _context.Remove(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Review review)
    {
        _context.Entry(review).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}