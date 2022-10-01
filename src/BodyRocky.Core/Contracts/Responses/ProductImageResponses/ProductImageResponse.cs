namespace BodyRocky.Core.Contracts.Responses.ProductImageResponses;

public class ProductImageResponse
{
    public Guid ProductImageID { get; init; } = default!;
    public string Image { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}