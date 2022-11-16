using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Baskets.GetOne;

public class GetOneBasketMapper
    : ResponseMapper<GetOneBasketResponse, Basket>
{
    public override GetOneBasketResponse FromEntity(Basket basket)
    {
        return new GetOneBasketResponse
        {
            BasketID = basket.BasketID,
            BasketStatus = basket.BasketStatus.Description,
            BasketDateAdded = basket.BasketDateAdded,
            Products = FromBasketProducts(basket.BasketProducts)
        };
    }

    private List<BasketItem> FromBasketProducts(IList<BasketProduct> basketProducts)
    {
        return basketProducts
            .Select(FromBasketProduct)
            .ToList();
    }

    private BasketItem FromBasketProduct(BasketProduct basketProduct)
    {
        return new BasketItem
        {
            ProductID = basketProduct.ProductID,
            ProductName = basketProduct.Product.ProductName,
            ProductPrice = basketProduct.Product.ProductPrice,
            Quantity = basketProduct.Quantity
        };
    }
}