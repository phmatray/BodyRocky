namespace BodyRocky.Core.Contracts.Data;

public class BrandDTO
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
}