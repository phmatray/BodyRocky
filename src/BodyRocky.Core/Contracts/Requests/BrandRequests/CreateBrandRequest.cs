namespace BodyRocky.Core.Contracts.Requests.BrandRequests;

public class CreateBrandRequest
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}