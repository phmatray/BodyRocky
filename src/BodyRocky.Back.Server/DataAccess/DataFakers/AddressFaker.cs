using Bogus;

namespace BodyRocky.Back.Server.DataAccess.DataFakers;

public sealed class AddressFaker
{
    private readonly Faker<Address> _faker;
    private readonly List<Guid> _ids = new();
    
    public AddressFaker(
        List<Guid> customerIds,
        List<Guid> zipCodeIds)
    {
        // we need a local copy of the ids to avoid the same id being used twice
        var localCustomerIds = customerIds.ToList();

        _faker = new Faker<Address>("fr")
            .StrictMode(false)
            .UseSeed(1111)
            .RuleFor(m => m.AddressID, f => f.Random.Guid())
            .RuleFor(m => m.AddressFromDate, f => f.Date.Past())
            .RuleFor(m => m.AddressToDate, f => f.Date.Future())
            .RuleFor(m => m.Street, f => f.Address.StreetAddress())
            .RuleFor(m => m.CustomerID, f =>
            {
                Guid random = f.PickRandom(localCustomerIds);
                localCustomerIds.Remove(random);
                return random;
            })
            .RuleFor(m => m.ZipCodeID, f => f.PickRandom(zipCodeIds));
    }

    public List<Address> Generate(int count)
    {
        var addresses = _faker.Generate(count);
        _ids.AddRange(addresses.Select(m => m.AddressID));
        return addresses;
    }

    public Address Generate()
        => Generate(1).First();

    public List<Guid> GetCopyOfIds()
        => _ids.ToList();
}