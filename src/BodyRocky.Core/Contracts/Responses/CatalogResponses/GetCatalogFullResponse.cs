namespace BodyRocky.Core.Contracts.Responses;

public class GetCatalogFullResponse
{
    public List<CategoryResponse> Categories { get; init; } = new();
    
    public List<ProductResponse> Products { get; init; } = new();
    
    public List<BrandResponse> Brands { get; init; } = new();

    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}