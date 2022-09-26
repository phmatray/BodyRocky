namespace BodyRocky.Core.Contracts.Responses.AddressResponses.BrandResponses;

public class BrandResponse
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}