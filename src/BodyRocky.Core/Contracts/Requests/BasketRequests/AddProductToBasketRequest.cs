namespace BodyRocky.Core.Contracts.Requests;

public class AddProductToBasketRequest
{
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}