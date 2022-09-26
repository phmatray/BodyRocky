namespace BodyRocky.Core.Contracts.Requests.CategoryRequests;

public class CreateCategoryRequest
{
    public Guid CategoryID { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
}