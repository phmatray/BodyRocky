namespace BodyRocky.Shared.Contracts.Requests;

public class CreateCategoryRequest
{
    public Guid CategoryID { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}