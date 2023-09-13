using BodyRocky.Back.Server.DataAccess.Factories;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers;

public class CustomerMapper
    : ResponseMapper<CustomerDetailsResponse, Customer>
{
    private readonly BasketFactory _basketFactory;

    public CustomerMapper(BasketFactory basketFactory)
    {
        _basketFactory = basketFactory;
    }

    public override CustomerDetailsResponse FromEntity(Customer customer)
    {
        Basket currentBasket = 
            // get the last basket associated with the customer
            customer.Baskets.MaxBy(b => b.BasketDateAdded)
            // or create a new one
            ?? _basketFactory.CreateEmptyBasket(customer.Id);

        return new CustomerDetailsResponse
        {
            CustomerID = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber,
            EmailAddress = customer.Email,
            CurrentBasket = FromBasket(currentBasket)
        };
    }

    private static BasketResponse FromBasket(Basket basket)
    {
        return new BasketResponse
        {
            BasketID = basket.BasketID,
            BasketDateAdded = basket.BasketDateAdded,
            BasketItems = FromBasketProducts(basket.BasketProducts)
        };
    }

    private static BasketItem[] FromBasketProducts(IEnumerable<BasketProduct> basketProducts)
    {
        return basketProducts
            .Select(FromBasketProduct)
            .ToArray();
    }

    private static BasketItem FromBasketProduct(BasketProduct basketProduct)
    {
        return new BasketItem
        {
            ProductID = basketProduct.Product.ProductID,
            ProductName = basketProduct.Product.ProductName,
            ProductPrice = basketProduct.Product.ProductPrice,
            Quantity = basketProduct.Quantity
        };
    }
}
