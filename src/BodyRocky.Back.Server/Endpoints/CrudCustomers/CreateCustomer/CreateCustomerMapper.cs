using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.CreateCustomer;

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