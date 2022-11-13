namespace BodyRocky.Core.Contracts.Responses;

public class BrandResponse
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
    public int ProductCount { get; set; }
}