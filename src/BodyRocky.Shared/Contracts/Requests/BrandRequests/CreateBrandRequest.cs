namespace BodyRocky.Shared.Contracts.Requests;

public class CreateBrandRequest
{
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}