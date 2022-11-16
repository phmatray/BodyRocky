namespace BodyRocky.Shared.Contracts.Responses;

public class OrderedProductResponse
{
    public Guid OrderedProductID { get; set; }
    public string OrderedProductName { get; set; }
    public string OrderedProductDescription { get; set; }
    public decimal OrderedProductPrice { get; set; }
    public int Quantity { get; set; }
}