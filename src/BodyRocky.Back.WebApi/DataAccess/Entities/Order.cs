namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Order
{
    public Guid OrderID { get; set; } = default!;
    public string BillingName { get; set; } = default!;
    public string Reference { get; set; } = default!;
    public string DeliveryName { get; set; } = default!;
    public DateTime PurchaseDate { get; set; } = default!;
    
    // relation customer
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = default!;
    
    // relation address
    public Guid BillingAddressId { get; set; } = default!;
    public Address BillingAddress { get; set; } = default!;
    public Guid DeliveryAddressId { get; set; } = default!;
    public Address DeliveryAddress { get; set; } = default!;
    
    
    // relation order status
    public int OrderStatusCode { get; set; } = default!;
    public OrderStatus OrderStatus { get; set; } = default!;
    
    // relation orderedProducts
    public IList<OrderedProduct> OrderedProducts { get; set; }
    
        public bool ValidateEntity()
    {
        return true;
    }
}