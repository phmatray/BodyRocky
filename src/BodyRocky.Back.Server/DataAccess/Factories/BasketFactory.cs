using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Enumerations;

namespace BodyRocky.Back.Server.DataAccess.Factories;

public class BasketFactory
{
    public Basket CreateEmptyBasket(Guid customerId)
    {
        return new Basket
        {
            BasketID = Guid.Empty,
            BasketDateAdded = DateTime.UtcNow,
            BasketStatusCode = (int)BasketStatusEnum.Empty,
            CustomerID = customerId,
            BasketProducts = new List<BasketProduct>()
        };
    }
    
    public Basket CreateBasketWithProducts(Guid customerId, IList<Product> products)
    {
        var basket = CreateEmptyBasket(customerId);
        basket.CustomerID = customerId;
        basket.BasketProducts = products.Select(p => new BasketProduct
        {
            BasketID = basket.BasketID,
            ProductID = p.ProductID,
            Quantity = 1
        }).ToList();
        return basket;
    }
}