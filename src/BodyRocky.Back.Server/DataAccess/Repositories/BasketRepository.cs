using BodyRocky.Back.Server.DataAccess.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace BodyRocky.Back.Server.DataAccess.Repositories;

public sealed class BasketRepository : IDisposable
{
    private readonly BodyRockyDbContext _context;

    public BasketRepository(BodyRockyDbContext context)
    {
        _context = context;
    }

    public async Task<int> CountAsync()
    {
        return await _context.Baskets.CountAsync();
    }

    public async Task<List<Basket>> GetAllAsync()
    {
        return await _context.Baskets
            .Include(basket => basket.BasketProducts)
            .ThenInclude(basketProduct => basketProduct.Product)
            .Include(basket => basket.BasketStatus)
            .ToListAsync();
    }

    public async Task<Basket?> GetByIDAsync(Guid basketID)
    {
        return await _context.Baskets
            .Include(basket => basket.BasketProducts)
            .ThenInclude(basketProduct => basketProduct.Product)
            .Include(basket => basket.BasketStatus)
            .SingleOrDefaultAsync(basket => basket.BasketID == basketID);
    }

    public async Task<Basket?> GetCurrentAsync(Guid customerID)
    {
        return await _context.Baskets
            .Include(basket => basket.BasketProducts)
            .ThenInclude(basketProduct => basketProduct.Product)
            .Include(basket => basket.BasketStatus)
            .Where(basket =>
                basket.CustomerID == customerID
                && basket.BasketStatusCode != (int)BasketStatusEnum.Paid)
            .OrderByDescending(basket => basket.BasketDateAdded)
            .FirstOrDefaultAsync();
    }

    public async Task InsertAsync(Basket basket)
    {
        await _context.Baskets.AddAsync(basket);
        await _context.SaveChangesAsync();
    }

    public async Task AddProductAsync(Guid basketID, Guid productID, int quantity)
    {
        Basket basket = await _context.Baskets.FindOrThrowAsync(basketID);
        Product product = await _context.Products.FindOrThrowAsync(productID);

        BasketProduct basketProduct = new BasketProduct
        {
            Quantity = quantity,
            Basket = basket,
            Product = product
        };

        basket.BasketProducts.Add(basketProduct);
        basket.BasketStatusCode = (int)BasketStatusEnum.NotEmpty;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveProductAsync(Guid basketID, Guid productID)
    {
        Basket basket = await _context.Baskets.FindOrThrowAsync(basketID);
        Product product = await _context.Products.FindOrThrowAsync(productID);

        BasketProduct? basketProduct = basket.BasketProducts
            .FirstOrDefault(x => x.ProductID == productID && x.BasketID == basketID);

        if (basketProduct is null)
            throw new Exception("Product not found in basket");

        basket.BasketProducts.Remove(basketProduct);

        if (basket.BasketProducts.Count == 0)
            basket.BasketStatusCode = (int)BasketStatusEnum.Empty;

        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductQuantityAsync(Guid basketID, Guid productID, int quantity)
    {
        Basket basket = await _context.Baskets.FindOrThrowAsync(basketID);
        Product product = await _context.Products.FindOrThrowAsync(productID);

        BasketProduct? basketProduct = basket.BasketProducts
            .FirstOrDefault(x => x.ProductID == productID && x.BasketID == basketID);

        if (basketProduct is null)
            throw new Exception("Product not found in basket");

        basketProduct.Quantity = quantity;

        if (basket.BasketProducts.Count == 0)
            basket.BasketStatusCode = (int)BasketStatusEnum.Empty;

        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
