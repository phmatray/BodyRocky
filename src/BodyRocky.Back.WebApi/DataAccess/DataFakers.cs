using BodyRocky.Back.WebApi.DataAccess.Entities;
using Bogus;

namespace BodyRocky.Back.WebApi.DataAccess;

public static class DataFakers
{
    public static Faker<Customer> FakerCustomer
        => new Faker<Customer>()
            .RuleFor(m => m.CustomerID, f => f.Random.Guid())
            .RuleFor(m => m.FirstName, f => f.Person.FirstName)
            .RuleFor(m => m.LastName, f => f.Person.LastName)
            .RuleFor(m => m.BirthDate, f => f.Date.Past(18))
            .RuleFor(m => m.Password, f => f.Random.Hash())
            .RuleFor(m => m.PhoneNumber, f => f.Person.Phone)
            .RuleFor(m => m.EmailAddress, f => f.Person.Email);
}