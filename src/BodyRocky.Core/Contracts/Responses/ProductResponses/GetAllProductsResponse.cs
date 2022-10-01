namespace BodyRocky.Core.Contracts.Responses.ProductResponses;

public class GetAllProductsResponse
{
    public IEnumerable<ProductResponse> Products { get; init; } = Enumerable.Empty<ProductResponse>();
}