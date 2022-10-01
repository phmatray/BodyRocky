using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.GetAllCustomers;

public class GetAllCustomersMapper
    : ResponseMapper<GetAllCustomersResponse, List<Customer>>
{
    public override GetAllCustomersResponse FromEntity(List<Customer> customers)
    {
        List<CustomerResponse> customerResponses = customers
            .Select(customer => new CustomerResponse
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress
            })
            .ToList();

        return new GetAllCustomersResponse()
        {
            Customers = customerResponses
        };
    }
}