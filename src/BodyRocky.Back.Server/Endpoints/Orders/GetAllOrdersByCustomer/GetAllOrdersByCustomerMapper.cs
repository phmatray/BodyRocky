namespace BodyRocky.Back.Server.Endpoints.Orders.GetAllOrdersByCustomer;

public class GetAllOrdersByCustomerMapper
    : FastEndpoints.ResponseMapper<GetAllOrdersByCustomerResponse, List<Order>>
{
    public override GetAllOrdersByCustomerResponse FromEntity(List<Order> orders)
    {
        return new GetAllOrdersByCustomerResponse
        {
            Orders = FromOrders(orders)
        };
    }

    private static List<OrderResponse> FromOrders(List<Order> orders)
    {
        return orders
            .Select(FromOrder)
            .ToList();
    }

    private static OrderResponse FromOrder(Order order)
    {
        OrderedProductResponse[] orderedProducts = order.OrderedProducts
            .Select(FromOrderedProduct)
            .ToArray();
        
        return new OrderResponse
        {
            OrderID = order.OrderID,
            BillingName = order.BillingName,
            Reference = order.Reference,
            DeliveryName = order.DeliveryName,
            PurchaseDate = order.PurchaseDate,
            OrderedProducts = orderedProducts
        };
    }

    private static OrderedProductResponse FromOrderedProduct(OrderedProduct product)
    {
        return new OrderedProductResponse
        {
            OrderedProductID = product.OrderedProductID,
            OrderedProductName = product.OrderedProductName,
            OrderedProductDescription = product.OrderedProductDescription,
            OrderedProductPrice = product.OrderedProductPrice,
            Quantity = product.Quantity
        };
    }
}