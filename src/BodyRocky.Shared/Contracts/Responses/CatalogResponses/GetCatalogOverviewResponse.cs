namespace BodyRocky.Shared.Contracts.Responses;

public class GetCatalogOverviewResponse
{
    public List<CategoryResponse> FeaturedCategories { get; init; } = new();

    public List<ProductResponse> FeaturedProducts { get; init; } = new();
    
    public List<ProductResponse> RecommendedProducts { get; set; } = new();
    
    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}