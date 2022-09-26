namespace BodyRocky.Core.Contracts.Responses.AddressResponses.CategoryResponses;

public class GetAllCategoriesResponse
{
    public IEnumerable<CategoryResponse> Categories { get; init; } = Enumerable.Empty<CategoryResponse>();
}