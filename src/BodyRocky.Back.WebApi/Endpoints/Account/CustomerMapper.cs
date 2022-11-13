using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Enumerations;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Account;

public class CustomerMapper
    : ResponseMapper<CustomerDetailsResponse, Customer>
{
    public override CustomerDetailsResponse FromEntity(Customer customer)
    {
        Basket currentBasket = 
            customer.Baskets.MaxBy(b => b.BasketDateAdded)
            ?? new Basket
            {
                BasketID = Guid.Empty,
                BasketDateAdded = DateTime.UtcNow,
                BasketStatusCode = (int)BasketStatusEnum.Empty,
                CustomerID = customer.Id,
                BasketProducts = new List<BasketProduct>()
            };

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
