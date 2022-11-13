namespace BodyRocky.Core.Contracts.Responses;

public class GetAllCategoriesResponse
{
    public IEnumerable<CategoryResponse> Categories { get; init; } = Enumerable.Empty<CategoryResponse>();
}