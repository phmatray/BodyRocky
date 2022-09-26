namespace BodyRocky.Core.Contracts.Responses.AddressResponses.ProductResponses;

public class GetAllProductsResponse
{
    public IEnumerable<ProductResponse> Products { get; init; } = Enumerable.Empty<ProductResponse>();
}