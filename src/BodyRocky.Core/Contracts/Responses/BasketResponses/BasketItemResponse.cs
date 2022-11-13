namespace BodyRocky.Core.Contracts.Responses;

public class BasketItemResponse
{
    public ProductResponse Product { get; init; } = default!;
    public int Quantity { get; init; }
}