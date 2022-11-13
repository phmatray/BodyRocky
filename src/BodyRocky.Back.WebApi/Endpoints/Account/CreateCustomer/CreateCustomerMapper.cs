using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Requests;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Account.CreateCustomer;

public class CreateCustomerMapper
    : Mapper<CreateCustomerRequest, CustomerDetailsResponse, Customer>
{
    public override Customer ToEntity(CreateCustomerRequest r)
    {
        // create a new customer using Identity
        return new Customer
        {
            Id = default,
            FirstName = r.FirstName,
            LastName = r.LastName,
            BirthDate = r.BirthDate,
            PhoneNumber = r.PhoneNumber,
            Email = r.EmailAddress
        };
    }

    public override CustomerDetailsResponse FromEntity(Customer customer)
    {
        return new CustomerDetailsResponse
        {
            CustomerID = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber,
            EmailAddress = customer.Email
        };
    }
}