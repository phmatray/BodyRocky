using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetOverview;

public class GetCatalogOverviewMapper
    : ResponseMapper<GetCatalogOverviewResponse, CatalogOverview>
{
    public override GetCatalogOverviewResponse FromEntity(CatalogOverview catalogOverview)
    {
        return new GetCatalogOverviewResponse
        {
            TotalProducts = catalogOverview.TotalProducts,
            TotalCategories = catalogOverview.TotalCategories,
            TotalBrands = catalogOverview.TotalBrands,
            FeaturedCategories = FromCategories(catalogOverview.FeaturedCategories),
            FeaturedProducts = FromProducts(catalogOverview.FeaturedProducts),
            RecommendedProducts = FromProducts(catalogOverview.RecommendedProducts)
        };
    }

    private static List<CategoryResponse> FromCategories(IEnumerable<Category> categories)
    {
        return categories
            .Select(FromCategory)
            .ToList();
    }

    private static CategoryResponse FromCategory(Category c)
    {
        return new CategoryResponse
        {
            CategoryID = c.CategoryID,
            CategoryName = c.CategoryName,
            CategoryImage = c.CategoryImage,
            CategoryIcon = c.CategoryIcon,
            IsFeatured = c.IsFeatured,
            ProductCount = c.ProductCategories.Count
        };
    }

    private static List<ProductResponse> FromProducts(IEnumerable<Product> products)
    {
        return products
            .Select(FromProduct)
            .ToList();
    }

    private static ProductResponse FromProduct(Product p)
    {
        return new ProductResponse
        {
            ProductID = p.ProductID,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            ProductPrice = p.ProductPrice,
            ProductURL = p.ProductURL,
            IsFeatured = p.IsFeatured,
            Stock = p.Stock
        };
    }
}