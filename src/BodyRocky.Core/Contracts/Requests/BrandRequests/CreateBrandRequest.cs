namespace BodyRocky.Core.Contracts.Requests.BrandRequests;

public class CreateBrandRequest
{
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}