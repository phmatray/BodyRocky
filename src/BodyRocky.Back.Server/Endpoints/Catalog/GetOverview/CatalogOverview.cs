namespace BodyRocky.Back.Server.Endpoints.Catalog.GetOverview;

public class CatalogOverview
{
    public CatalogOverview(
        List<Category> featuredCategories,
        List<Product> featuredProducts,
        List<Product> recommendedProducts)
    {
        FeaturedCategories = featuredCategories;
        FeaturedProducts = featuredProducts;
        RecommendedProducts = recommendedProducts;
    }

    public List<Category> FeaturedCategories { get; }
    
    public List<Product> FeaturedProducts { get; }
    
    public List<Product> RecommendedProducts { get; }

    public int TotalProducts { get; init; }
    
    public int TotalCategories { get; init; }
    
    public int TotalBrands { get; init; }
}