using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Enumerations;
using BodyRocky.Back.WebApi.DataAccess.Repositories;

namespace BodyRocky.Back.WebApi.Services;

public class BasketService
{
    private readonly BasketRepository _basketRepository;
    
    public BasketService(BasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    
    public async Task<Basket> CreateEmptyBasketAsync(Guid customerId)
    {
        var basket = new Basket
        {
            BasketDateAdded = DateTime.UtcNow,
            BasketProducts = new List<BasketProduct>(),
            BasketStatusCode = (int)BasketStatusEnum.Empty,
            CustomerID = customerId,
        };
        
        await _basketRepository.InsertAsync(basket);
        
        return basket;
    }
    
    public async Task<Basket> GetBasketAsync(Guid customerId)
    {
        Basket current =
            await _basketRepository.GetCurrentAsync(customerId)
            ?? await CreateEmptyBasketAsync(customerId);
        
        return current;
    }

    public async Task AddProductToBasketAsync(
        Guid customerId,
        Guid productId,
        int quantity = 1)
    {
        var basket = await GetBasketAsync(customerId);
        
        // check if product is already in basket...
        var basketItem = basket.BasketProducts?
            .FirstOrDefault(bi => bi.ProductID == productId);
        
        if (basketItem != null)
        {
            // ...if so, increase quantity
            int newQuantity = basketItem.Quantity + quantity;
            await _basketRepository.UpdateProductQuantityAsync(basket.BasketID, productId, newQuantity);
        }
        else
        {
            // ...otherwise, add the product to the basket
            await _basketRepository.AddProductAsync(basket.BasketID, productId, quantity);
        }
    }
}