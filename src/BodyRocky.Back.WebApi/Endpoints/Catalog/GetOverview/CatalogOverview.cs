using BodyRocky.Back.WebApi.DataAccess.Entities;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetOverview;

public class CatalogOverview
{
    public CatalogOverview(
        List<Category> featuredCategories,
        List<Product> featuredProducts)
    {
        FeaturedProducts = featuredProducts;
        FeaturedCategories = featuredCategories;
    }

    public List<Product> FeaturedProducts { get; }

    public List<Category> FeaturedCategories { get; }
    
    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}