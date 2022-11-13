namespace BodyRocky.Core.Contracts.Responses;

public class GetAllBrandsResponse
{
    public IEnumerable<BrandResponse> Brands { get; init; } = Enumerable.Empty<BrandResponse>();
}