using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Core.Contracts.Responses.ProductResponses;

namespace BodyRocky.Core.Contracts.Responses.CatalogResponses;

public class GetOverviewCatalogResponse
{
    public List<ProductResponse> FeaturedProducts { get; init; } = new();
    
    public List<CategoryResponse> FeaturedCategories { get; init; } = new();
    
    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}