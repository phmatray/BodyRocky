namespace BodyRocky.Core.Contracts.Responses.AddressResponses.ProductResponses;

public class ProductResponse
{
    public Guid ProductId { get; init; } = default!;
    public string ProductName { get; init; } = default!;
    public string ProductDescription { get; init; } = default!;
    public float ProductPrice { get; init; } = default!;
    public string ProductURL { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}