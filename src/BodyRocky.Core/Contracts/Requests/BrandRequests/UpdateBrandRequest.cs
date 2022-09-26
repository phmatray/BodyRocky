namespace BodyRocky.Core.Contracts.Requests.BrandRequests;

public class UpdateBrandRequest
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}