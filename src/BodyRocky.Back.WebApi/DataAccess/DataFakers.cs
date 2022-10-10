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

    public static Faker<Category> FakerCategory
        => new Faker<Category>()
            .RuleFor(m => m.CategoryID, f => f.Random.Guid())
            .RuleFor(m => m.CategoryName, f => f.Commerce.Categories(1).ToString())
            .RuleFor(m => m.IsFeatured, f => f.Random.Bool());

    public static Faker<Address> FakerAddress
        => new Faker<Address>()
            .RuleFor(m => m.AddressID, f => f.Random.Guid())
            .RuleFor(m => m.AddressFromDate, f => f.Date.Past(1))
            .RuleFor(m => m.AddressToDate, f => f.Date.Future(1))
            .RuleFor(m => m.Street, f => f.Address.StreetAddress());
}