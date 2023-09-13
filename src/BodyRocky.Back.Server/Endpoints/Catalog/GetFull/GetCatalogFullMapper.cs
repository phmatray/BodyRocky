using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetFull;

public class GetCatalogFullMapper
    : ResponseMapper<GetCatalogFullResponse, CatalogFull>
{
    public override GetCatalogFullResponse FromEntity(CatalogFull catalog)
    {
        List<CategoryResponse> categoryResponses = catalog
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
        
        List<ProductResponse> productResponses = catalog
            .Products
            .Select(p => new ProductResponse
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductURL = p.ProductURL,
                IsFeatured = p.IsFeatured,
                Stock = p.Stock,
                ProductCategory = p.ProductCategories.FirstOrDefault()?.Category.CategoryName ?? string.Empty
            })
            .ToList();
        
        List<BrandResponse> brandResponses = catalog
            .Brands
            .Select(b => new BrandResponse
            {
                BrandID = b.BrandID,
                BrandName = b.BrandName,
                BrandLogo = b.BrandLogo,
                ProductCount = b.Products.Count
            })
            .ToList();

        return new GetCatalogFullResponse
        {
            TotalProducts = catalog.TotalProducts,
            TotalCategories = catalog.TotalCategories,
            TotalBrands = catalog.TotalBrands,
            Categories = categoryResponses,
            Products = productResponses,
            Brands = brandResponses
        };
    }
}