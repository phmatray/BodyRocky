namespace BodyRocky.Shared.Contracts.Responses;

public class BasketItem
{
    public Guid ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int Quantity { get; set; }
}