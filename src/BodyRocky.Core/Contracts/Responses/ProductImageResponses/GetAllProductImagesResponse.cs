namespace BodyRocky.Core.Contracts.Responses.AddressResponses.ProductImageResponses;

public class GetAllProductImagesResponse
{
    public IEnumerable<ProductImageResponse> ProductImages { get; init; } = Enumerable.Empty<ProductImageResponse>();
}