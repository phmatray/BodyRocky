namespace BodyRocky.Core.Contracts.Responses;

public class CategoryResponse
{
    public Guid CategoryID { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public string CategoryImage { get; init; } = default!;
    public string CategoryIcon { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
    public int ProductCount { get; init; } = default!;
}