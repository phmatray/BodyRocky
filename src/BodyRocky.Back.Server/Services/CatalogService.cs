using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Back.Server.Endpoints.Catalog.GetFull;
using BodyRocky.Back.Server.Endpoints.Catalog.GetOverview;

namespace BodyRocky.Back.Server.Services;

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
    
    public async Task<CatalogOverview> GetCatalogOverviewAsync()
    {
        List<Category> featuredCategories = await _categoryRepository.GetTop6FeaturedAsync();
        List<Product> featuredProducts = await _productRepository.GetTop4FeaturedAsync();
        List<Product> recommendedProducts = await _productRepository.GetTop8RecommendedAsync();

        int totalProducts = await _productRepository.CountAsync();
        int totalCategories = await _categoryRepository.CountAsync();
        int totalBrands = await _brandRepository.CountAsync();

        return new CatalogOverview(
            featuredCategories,
            featuredProducts,
            recommendedProducts)
        {
            TotalProducts = totalProducts,
            TotalCategories = totalCategories,
            TotalBrands = totalBrands
        };
    }
    
    public async Task<CatalogFull> GetCatalogFullAsync()
    {
        List<Category> categories = await _categoryRepository.GetAllAsync();
        List<Product> products = await _productRepository.GetAllAsync();
        List<Brand> brands = await _brandRepository.GetAllAsync();

        return new CatalogFull(categories, products, brands);
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync();

        return products;
    }
    
    public async Task<Product?> GetProductAsync(Guid id)
    {
        Product? product = await _productRepository.GetByIDAsync(id);

        return product;
    }
    
    public async Task<List<Category>> GetBrandsAsync()
    {
        List<Category> brands = await _categoryRepository.GetAllAsync();

        return brands;
    }
    
    public async Task DeleteProductAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}