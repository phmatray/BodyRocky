using BodyRocky.Back.Server.DataAccess.Factories;
using BodyRocky.Back.Server.DataAccess.Repositories;

namespace BodyRocky.Back.Server.Services;

public class BasketService
{
    private readonly BasketRepository _basketRepository;
    private readonly BasketFactory _basketFactory;
    
    public BasketService(
        BasketRepository basketRepository,
        BasketFactory basketFactory)
    {
        _basketRepository = basketRepository;
        _basketFactory = basketFactory;
    }
    
    public async Task<Basket> CreateEmptyBasketAsync(Guid customerId)
    {
        var basket = _basketFactory.CreateEmptyBasket(customerId);
        
        await _basketRepository.InsertAsync(basket);
        
        return basket;
    }
    
    public async Task<Basket> GetBasketAsync(Guid customerId)
    {
        Basket? current = await _basketRepository.GetCurrentAsync(customerId);

        if (current is null)
        {
            current = await CreateEmptyBasketAsync(customerId);
            await _basketRepository.InsertAsync(current);
        }

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