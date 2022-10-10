using BodyRocky.Back.WebApi.DataAccess.Entities;
using Bogus;

namespace BodyRocky.Back.WebApi.DataAccess;

public static class FakeData
{
    private static Faker<Brand>? _fakeBrand;
    private static Faker<Category>? _fakeCategory;
    private static Faker<Customer>? _fakeCustomer;
    private static Faker<ZipCode>? _fakeZipCode;
    private static Faker<Address>? _fakeAddress;
    private static Faker<Product>? _fakeProduct;

    public static List<Brand>? Brands;
    public static List<Category>? Categories;
    public static List<Customer>? Customers;
    public static List<ZipCode>? ZipCodes;
    public static List<Address>? Addresses;
    public static List<Product>? Products;

    public static void Init()
    {
        const int numToSeed = 40;

        #region Brands
        
        List<Guid> brandIds = new();
        
        _fakeBrand = new Faker<Brand>()
            .StrictMode(false)
            .UseSeed(3333)
            .RuleFor(m => m.BrandID, f =>
            {
                Guid guid = f.Random.Guid();
                brandIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.BrandName, f => f.Company.CompanyName())
            .RuleFor(m => m.BrandLogo, f => f.Image.PicsumUrl());
        
        Brands = _fakeBrand.Generate(numToSeed);
        
        #endregion
        
        #region Categories

        List<Guid> categoryIds = new();
        
        _fakeCategory = new Faker<Category>()
            .StrictMode(false)
            .UseSeed(2222)
            .RuleFor(m => m.CategoryID, f =>
            {
                Guid guid = f.Random.Guid();
                categoryIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.CategoryName, f => f.Commerce.Categories(1).First())
            .RuleFor(m => m.IsFeatured, f => f.Random.Bool());
        
        Categories = _fakeCategory.Generate(numToSeed);
        
        #endregion
        
        #region Customers

        List<Guid> customerIds = new();
        
        _fakeCustomer = new Faker<Customer>()
            .StrictMode(false)
            .UseSeed(1111)
            .RuleFor(m => m.CustomerID, f =>
            {
                Guid guid = f.Random.Guid();
                customerIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.FirstName, f => f.Person.FirstName)
            .RuleFor(m => m.LastName, f => f.Person.LastName)
            .RuleFor(m => m.BirthDate, f => f.Date.Past(18))
            .RuleFor(m => m.Password, f => f.Random.Hash())
            .RuleFor(m => m.PhoneNumber, f => f.Person.Phone)
            .RuleFor(m => m.EmailAddress, f => f.Person.Email);
        
        Customers = _fakeCustomer.Generate(numToSeed);
        
        #endregion
        
        #region ZipCodes
        
        List<Guid> zipCodeIds = new();

        _fakeZipCode = new Faker<ZipCode>()
            .StrictMode(false)
            .UseSeed(4444)
            .RuleFor(m => m.ZipCodeID, f =>
            {
                Guid guid = f.Random.Guid();
                zipCodeIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.Code, f => f.Random.Number(1000, 9999))
            .RuleFor(m => m.Commune, f => f.Address.City());
        
        ZipCodes = _fakeZipCode.Generate(numToSeed);
        
        #endregion
        
        #region Addresses
        
        List<Guid> addressIds = new();
        
        _fakeAddress = new Faker<Address>()
            .StrictMode(false)
            .UseSeed(1111)
            .RuleFor(m => m.AddressID, f =>
            {
                Guid guid = f.Random.Guid();
                customerIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.AddressFromDate, f => f.Date.Past(1))
            .RuleFor(m => m.AddressToDate, f => f.Date.Future(1))
            .RuleFor(m => m.Street, f => f.Address.StreetAddress())
            .RuleFor(m => m.CustomerID, f =>
            {
                Guid random = f.PickRandom(customerIds);
                customerIds.Remove(random);
                return random;
            })
            .RuleFor(m => m.ZipCodeID, f =>
            {
                Guid random = f.PickRandom(zipCodeIds);
                zipCodeIds.Remove(random);
                return random;
            });
        
        Addresses = _fakeAddress.Generate(numToSeed);
        
        #endregion
        
        #region Products
        
        List<Guid> productIds = new();

        _fakeProduct = new Faker<Product>()
            .StrictMode(false)
            .UseSeed(5555)
            .RuleFor(m => m.ProductID, f =>
            {
                Guid guid = f.Random.Guid();
                productIds.Add(guid);
                return guid;
            })
            .RuleFor(m => m.ProductName, f => f.Commerce.ProductName())
            .RuleFor(m => m.ProductDescription, f => f.Commerce.ProductDescription())
            .RuleFor(m => m.ProductPrice, f => f.Random.Decimal(0, 100))
            .RuleFor(m => m.ProductURL, f => f.Image.PicsumUrl())
            .RuleFor(m => m.IsFeatured, f => f.Random.Bool())
            .RuleFor(m => m.BrandID, f =>
            {
                Guid random = f.PickRandom(brandIds);
                brandIds.Remove(random);
                return random;
            });
        
        Products = _fakeProduct.Generate(numToSeed);
        
        #endregion
    }
}
