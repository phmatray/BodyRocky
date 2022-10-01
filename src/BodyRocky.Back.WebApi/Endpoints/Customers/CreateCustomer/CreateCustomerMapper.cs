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
        return new Customer
        {
            CustomerID = default,
            FirstName = r.FirstName,
            LastName = r.LastName,
            BirthDate = r.BirthDate,
            Password = r.Password,
            PhoneNumber = r.PhoneNumber,
            EmailAddress = r.EmailAddress
        };
    }

    public override CustomerResponse FromEntity(Customer customer)
    {
        return new CustomerResponse
        {
            CustomerID = customer.CustomerID,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber,
            EmailAddress = customer.EmailAddress
        };
    }
}