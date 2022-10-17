using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.CreateCustomer;

public class CreateCustomerMapper
    : Mapper<CreateCustomerRequest, CustomerResponse, Customer>
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

    public override CustomerResponse FromEntity(Customer customer)
    {
        return new CustomerResponse
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