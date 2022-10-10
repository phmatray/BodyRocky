using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Endpoints.Catalog.GetOverview;

namespace BodyRocky.Back.WebApi.Services;

public class CatalogService
{
    private readonly CategoryRepository _categoryRepository;
    private readonly ProductRepository _productRepository;
    private readonly BrandRepository _brandRepository;
    
    public CatalogService(
        CategoryRepository categoryRepository,
        ProductRepository productRepository,
        BrandRepository brandRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _brandRepository = brandRepository;
    }
    
    public async Task<CatalogOverview> GetOverviewAsync()
    {
        List<Category> featuredCategories = await _categoryRepository.GetTop5FeaturedAsync();
        List<Product> featuredProducts = await _productRepository.GetTop5FeaturedAsync();
        
        int totalProducts = await _productRepository.CountAsync();
        int totalCategories = await _categoryRepository.CountAsync();
        int totalBrands = await _brandRepository.CountAsync();

        return new CatalogOverview(featuredCategories, featuredProducts)
        {
            TotalProducts = totalProducts,
            TotalCategories = totalCategories,
            TotalBrands = totalBrands
        };
    }
}