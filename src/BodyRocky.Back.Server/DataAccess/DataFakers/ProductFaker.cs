using Bogus;

namespace BodyRocky.Back.Server.DataAccess.DataFakers;

public sealed class ProductFaker
{
    private readonly Faker<Product> _faker;
    private readonly List<Guid> _ids = new();
    
    public ProductFaker(
        List<Guid> brandIds)
    {
        _faker = new Faker<Product>("fr")
            .StrictMode(false)
            .UseSeed(5555)
            .RuleFor(m => m.ProductID, f => f.Commerce.Random.Guid())
            .RuleFor(m => m.ProductName, f => f.Commerce.ProductName())
            .RuleFor(m => m.ProductDescription, f => f.Commerce.ProductDescription())
            .RuleFor(m => m.ProductPrice, f => f.Commerce.Random.Decimal(0, 100))
            .RuleFor(m => m.ProductURL, f => f.Image.PicsumUrl())
            .RuleFor(m => m.IsFeatured, f => f.Commerce.Random.Bool())
            .RuleFor(m => m.Stock, f => f.Commerce.Random.Number(0, 50))
            .RuleFor(m => m.BrandID, f => f.PickRandom(brandIds));
    }

    public List<Product> Generate(int count)
    {
        List<Product> products = _faker.Generate(count);
        _ids.AddRange(products.Select(m => m.ProductID));
        return products;
    }
    
    public Product Generate()
        => Generate(1).First();

    public List<Guid> GetCopyOfIds()
        => _ids.ToList();
}