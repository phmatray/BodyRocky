using BodyRocky.Back.Server.DataAccess.Enumerations;

namespace BodyRocky.Back.Server.DataAccess.Factories;

public class OrderFactory
{
    public Order CreateOrder(
        Basket basket,
        Customer customer,
        Guid billingAddressID,
        Guid deliveryAddressID)
    {
        string billingName = $"{customer.FirstName} {customer.LastName}";
        
        OrderedProduct[] orderedProducts = basket.BasketProducts
            .Select(bp => new OrderedProduct
            {
                OrderedProductName = bp.Product.ProductName,
                OrderedProductDescription = bp.Product.ProductDescription,
                OrderedProductPrice = bp.Product.ProductPrice,
                ProductID = bp.ProductID,
                Quantity = bp.Quantity
            })
            .ToArray();
        
        return new Order
        {
            BillingName = billingName,
            Reference = Guid.NewGuid().ToString(),
            DeliveryName = billingName,
            PurchaseDate = DateTime.UtcNow,
            CustomerID = customer.Id,
            BillingAddressID = billingAddressID,
            DeliveryAddressID = deliveryAddressID,
            OrderStatusCode = (int)OrderStatusEnum.Created,
            OrderedProducts = orderedProducts

        };
    }
}