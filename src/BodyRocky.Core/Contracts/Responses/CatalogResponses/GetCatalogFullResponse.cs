using BodyRocky.Core.Contracts.Responses.BrandResponses;
using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Core.Contracts.Responses.ProductResponses;

namespace BodyRocky.Core.Contracts.Responses.CatalogResponses;

public class GetCatalogFullResponse
{
    public List<CategoryResponse> Categories { get; init; } = new();
    
    public List<ProductResponse> Products { get; init; } = new();
    
    public List<BrandResponse> Brands { get; init; } = new();

    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}