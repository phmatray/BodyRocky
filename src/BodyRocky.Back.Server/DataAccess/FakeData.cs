using BodyRocky.Back.Server.DataAccess.DataFakers;

namespace BodyRocky.Back.Server.DataAccess;

public static class FakeData
{
    public static List<Brand>? Brands;
    public static List<Customer>? Customers;
    public static List<Address>? Addresses;
    public static List<Product>? Products;
    public static List<ProductCategory>? ProductCategories;

    public static void Init()
    {
        var basketStatusCodes = ReferentialData
            .GetPredefinedBasketStatuses()
            .Select(x => x.Code)
            .ToList();

        var orderStatusCodes = ReferentialData
            .GetPredefinedOrderStatuses()
            .Select(x => x.Code)
            .ToList();

        var zipCodeIds = ReferentialData
            .GetPredefinedZipCodes()
            .Select(x => x.ZipCodeID)
            .ToList();
        
        var categoryIds = ReferentialData
            .GetPredefinedCategories()
            .Select(c => c.CategoryID)
            .ToList();

        // brand
        const int numBrands = 10;
        BrandFaker brandFaker = new();
        Brands = brandFaker.Generate(numBrands);
        var brandIds = brandFaker.GetCopyOfIds();

        // customer
        const int numCustomers = 20;
        CustomerFaker customerFaker = new();    
        Customers = customerFaker.Generate(numCustomers);
        var customerIds = customerFaker.GetCopyOfIds();
        
        // address
        const int numAddresses = 20;
        AddressFaker addressFaker = new(customerIds, zipCodeIds);
        Addresses = addressFaker.Generate(numAddresses);
        var addressIds = addressFaker.GetCopyOfIds();
        
        // product
        const int numProducts = 100;
        ProductFaker productFaker = new(brandIds);
        Products = productFaker.Generate(numProducts);
        var productIds = productFaker.GetCopyOfIds();
        
        // product category
        const int numProductCategories = 100;
        ProductCategoryFaker productCategoryFaker = new(productIds, categoryIds);
        ProductCategories = productCategoryFaker.Generate(numProductCategories);
    }
}
