namespace BodyRocky.Shared.Contracts.Responses;

public class ProductResponse
{
    public Guid ProductID { get; init; } = default!;
    public string ProductName { get; init; } = default!;
    public string ProductDescription { get; init; } = default!;
    public decimal ProductPrice { get; init; } = default!;
    public string ProductURL { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
    public int Stock { get; init; }
    public string ProductCategory { get; set; } = default!;
}