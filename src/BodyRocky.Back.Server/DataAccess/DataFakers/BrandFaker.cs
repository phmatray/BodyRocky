using Bogus;

namespace BodyRocky.Back.Server.DataAccess.DataFakers;

public sealed class BrandFaker
{
    private readonly Faker<Brand> _faker;
    private readonly List<Guid> _ids = new();
    
    public BrandFaker()
    {
        _faker = new Faker<Brand>("fr")
            .StrictMode(false)
            .UseSeed(3333)
            .RuleFor(m => m.BrandID, f => f.Company.Random.Guid())
            .RuleFor(m => m.BrandName, f => f.Company.CompanyName())
            .RuleFor(m => m.BrandLogo, f => f.Image.PicsumUrl());
    }

    public List<Brand> Generate(int count)
    {
        List<Brand> brands = _faker.Generate(count);
        _ids.AddRange(brands.Select(m => m.BrandID));
        return brands;
    }

    public Brand Generate()
        => Generate(1).First();

    public List<Guid> GetCopyOfIds()
        => _ids.ToList();
}