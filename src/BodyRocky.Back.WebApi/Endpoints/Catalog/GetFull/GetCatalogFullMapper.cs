using BodyRocky.Core.Contracts.Responses.BrandResponses;
using BodyRocky.Core.Contracts.Responses.CatalogResponses;
using BodyRocky.Core.Contracts.Responses.CategoryResponses;
using BodyRocky.Core.Contracts.Responses.ProductResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetFull;

public class GetCatalogFullMapper
    : ResponseMapper<GetCatalogFullResponse, CatalogFull>
{
    public override GetCatalogFullResponse FromEntity(CatalogFull catalogOverview)
    {
        List<CategoryResponse> categoryResponses = catalogOverview
            .Categories
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
        
        List<ProductResponse> productResponses = catalogOverview
            .Products
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
        
        List<BrandResponse> brandResponses = catalogOverview
            .Brands
            .Select(b => new BrandResponse
            {
                BrandID = b.BrandID,
                BrandName = b.BrandName,
                BrandLogo = b.BrandLogo
            })
            .ToList();

        return new GetCatalogFullResponse
        {
            TotalProducts = catalogOverview.TotalProducts,
            TotalCategories = catalogOverview.TotalCategories,
            TotalBrands = catalogOverview.TotalBrands,
            Categories = categoryResponses,
            Products = productResponses,
            Brands = brandResponses
        };
    }
}