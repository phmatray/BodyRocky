using BodyRocky.Back.Server.DataAccess.Entities;
using Bogus;

namespace BodyRocky.Back.Server.DataAccess.DataFakers;

public sealed class CustomerFaker
{
    private readonly Faker<Customer> _faker;
    private readonly List<Guid> _ids = new();
    
    public CustomerFaker()
    {
        _faker = new Faker<Customer>("fr")
            .StrictMode(false)
            .UseSeed(1111)
            .RuleFor(m => m.Id, f => f.Person.Random.Guid())
            .RuleFor(m => m.FirstName, f => f.Person.FirstName)
            .RuleFor(m => m.LastName, f => f.Person.LastName)
            .RuleFor(m => m.BirthDate, f => f.Person.DateOfBirth)
            .RuleFor(m => m.PasswordHash, f => f.Person.Random.Hash())
            .RuleFor(m => m.PhoneNumber, f => f.Person.Phone)
            .RuleFor(m => m.Email, f => f.Person.Email);
    }

    public List<Customer> Generate(int count)
    {
        List<Customer> customers = _faker.Generate(count);
        _ids.AddRange(customers.Select(c => c.Id));
        return customers;
    }
    
    public Customer Generate()
        => Generate(1).First();

    public List<Guid> GetCopyOfIds()
        => _ids.ToList();
}