using Bogus;

namespace BodyRocky.Back.Server.DataAccess.DataFakers;

public sealed class ProductCategoryFaker
{
    private readonly Faker<ProductCategory> _faker;
    private readonly List<Guid> _ids = new();

    public ProductCategoryFaker(
        List<Guid> productIds,
        List<Guid> categoryIds)
    {
        // we need a local copy of the ids to avoid the same id being used twice
        List<Guid> localProductIds = new(productIds);

        _faker = new Faker<ProductCategory>("fr")
            .StrictMode(false)
            .UseSeed(6666)
            .RuleFor(m => m.ProductID, f =>
            {
                Guid random = f.PickRandom(localProductIds);
                localProductIds.Remove(random);
                return random;
            })
            .RuleFor(m => m.CategoryID, f =>
            {
                Guid random = f.PickRandom(categoryIds);
                return random;
            });
    }
    
    public List<ProductCategory> Generate(int count)
        => _faker.Generate(count);
    
    public ProductCategory Generate()
        => _faker.Generate();
    
    public List<Guid> GetCopyOfIds()
        => _ids.ToList();
}