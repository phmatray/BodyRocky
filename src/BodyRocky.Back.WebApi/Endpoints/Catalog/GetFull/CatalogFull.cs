using BodyRocky.Back.WebApi.DataAccess.Entities;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetFull;

public class CatalogFull
{
    public CatalogFull(
        List<Category> categories,
        List<Product> products,
        List<Brand> brands)
    {
        Categories = categories;
        Products = products;
        Brands = brands;
        
        TotalProducts = products.Count;
        TotalCategories = categories.Count;
        TotalBrands = brands.Count;
    }
    
    public List<Category> Categories { get; }
    
    public List<Product> Products { get; }
    
    public List<Brand> Brands { get; }
    
    public int TotalProducts { get; }
    
    public int TotalCategories { get; }
    
    public int TotalBrands { get; }
}