namespace BodyRocky.Core.Contracts.Responses;

public class GetAllProductImagesResponse
{
    public IEnumerable<ProductImageResponse> ProductImages { get; init; } = Enumerable.Empty<ProductImageResponse>();
}