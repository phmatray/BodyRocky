using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.WebApi.DataAccess;

public static class DbSetExtensions
{
    /// <summary>
    /// Find an entity by its primary key or throw an exception if not found.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="dbSet">The db set.</param>
    /// <param name="keyValues">The key values.</param>
    /// <returns>The entity.</returns>
    /// <exception cref="System.InvalidOperationException">The entity of type {0} with key {1} was not found.</exception>
    public static TEntity FindOrThrow<TEntity>(
        this DbSet<TEntity> dbSet,
        params object[] keyValues)
        where TEntity : class
    {
        var entity = dbSet.Find(keyValues);
        if (entity != null)
        {
            return entity;
        }

        var message = FormatNotFoundMessage<TEntity>(keyValues);
        throw new InvalidOperationException(message);
    }
    
    /// <summary>
    /// Find an entity by its primary key or throw an exception if not found.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="dbSet">The db set.</param>
    /// <param name="keyValues">The key values.</param>
    /// <returns>The entity.</returns>
    /// <exception cref="System.InvalidOperationException">The entity of type {0} with key {1} was not found.</exception>
    public static async Task<TEntity> FindOrThrowAsync<TEntity>(
        this DbSet<TEntity> dbSet,
        params object[] keyValues)
        where TEntity : class
    {
        var entity = await dbSet.FindAsync(keyValues);
        if (entity != null)
        {
            return entity;
        }

        var message = FormatNotFoundMessage<TEntity>(keyValues);
        throw new InvalidOperationException(message);
    }

    private static string FormatNotFoundMessage<TEntity>(object[] keyValues)
        where TEntity : class
    {
        string entityName = typeof(TEntity).Name;
        string entityKeyValues = string.Join(", ", keyValues);
        return $"The entity of type {entityName} with key {entityKeyValues} was not found.";
    }
}