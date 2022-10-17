using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers;

public class CustomerMapper
    : ResponseMapper<CustomerResponse, Customer>
{
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