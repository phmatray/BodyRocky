using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Factories;
using BodyRocky.Shared.Contracts.Responses;
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
            customer.Baskets.MaxBy(b => b.BasketDateAdded)
            ?? _basketFactory.CreateEmptyBasket(customer.Id);

        var basketItemResponses = currentBasket?
            .BasketProducts
            .Select(bp => new BasketItemResponse
            {
                Product = new ProductResponse
                {
                    ProductID = bp.Product.ProductID,
                    ProductName = bp.Product.ProductName,
                    ProductDescription = bp.Product.ProductDescription,
                    ProductPrice = bp.Product.ProductPrice,
                    ProductURL = bp.Product.ProductURL,
                    IsFeatured = bp.Product.IsFeatured,
                    Stock = bp.Product.Stock,
                    ProductCategory = "PLACEHOLDER" 
                },
                Quantity = bp.Quantity,
            })
            .ToList();
        
        BasketResponse basketResponse = new()
        {
            BasketID = currentBasket.BasketID,
            BasketDateAdded = currentBasket.BasketDateAdded,
            BasketItems = basketItemResponses
        };

        return new CustomerDetailsResponse
        {
            CustomerID = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber,
            EmailAddress = customer.Email,
            CurrentBasket = basketResponse
        };
    }
}
