namespace BodyRocky.Core.Contracts.Responses.AddressResponses.BrandResponses;

public class GetAllBrandsResponse
{
    public IEnumerable<BrandResponse> Brands { get; init; } = Enumerable.Empty<BrandResponse>();
}