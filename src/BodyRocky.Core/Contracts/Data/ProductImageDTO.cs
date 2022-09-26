namespace BodyRocky.Core.Contracts.Data;

public class ProductImageDTO
{
    public Guid ProductImageID { get; init; } = default!;
    public string Image { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}