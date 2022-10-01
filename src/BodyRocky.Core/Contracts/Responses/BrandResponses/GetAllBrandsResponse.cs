namespace BodyRocky.Core.Contracts.Responses.BrandResponses;

public class GetAllBrandsResponse
{
    public IEnumerable<BrandResponse> Brands { get; init; } = Enumerable.Empty<BrandResponse>();
}