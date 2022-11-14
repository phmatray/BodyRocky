namespace BodyRocky.Back.Server.DataAccess.Entities;

public class OrderedProduct
{
    public Guid OrderedProductID { get; set; } = default!;
    public string OrderedProductName { get; set; } = default!;
    public string OrderedProductDescription { get; set; } = default!;
    public decimal OrderedProductPrice { get; set; }
    public int Quantity { get; set; }
    
    // relation product
    public Guid ProductID { get; set; }
    public Product Product { get; set; } = default!;
    
    // relation order
    public Guid OrderID { get; set; }
    public Order Order { get; set; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
    
}