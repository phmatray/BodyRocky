using BodyRocky.Core.Contracts.Responses.CatalogResponses;
using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Core.Contracts.Responses.ProductResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetOverview;

public class GetOverviewCatalogMapper
    : ResponseMapper<GetOverviewCatalogResponse, CatalogOverview>
{
    public override GetOverviewCatalogResponse FromEntity(CatalogOverview catalogOverview)
    {
        List<CategoryResponse> featuredCategoryResponses = catalogOverview
            .FeaturedCategories
            .Select(c => new CategoryResponse
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                CategoryImage = c.CategoryImage,
                CategoryIcon = c.CategoryIcon,
                IsFeatured = c.IsFeatured,
                ProductCount = c.ProductCategories.Count
            })
            .ToList();
        
        List<ProductResponse> featuredProductResponses = catalogOverview
            .FeaturedProducts
            .Select(p => new ProductResponse
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductURL = p.ProductURL,
                IsFeatured = p.IsFeatured
            })
            .ToList();
        
        List<ProductResponse> recommendedProductResponses = catalogOverview
            .RecommendedProducts
            .Select(p => new ProductResponse
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductURL = p.ProductURL,
                IsFeatured = p.IsFeatured
            })
            .ToList();

        return new GetOverviewCatalogResponse
        {
            TotalProducts = catalogOverview.TotalProducts,
            TotalCategories = catalogOverview.TotalCategories,
            TotalBrands = catalogOverview.TotalBrands,
            FeaturedCategories = featuredCategoryResponses,
            FeaturedProducts = featuredProductResponses,
            RecommendedProducts = recommendedProductResponses
        };
    }
}