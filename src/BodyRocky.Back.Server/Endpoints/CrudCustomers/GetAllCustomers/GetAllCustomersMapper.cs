using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.GetAllCustomers;

public class GetAllCustomersMapper
    : ResponseMapper<GetAllCustomersResponse, List<Customer>>
{
    public override GetAllCustomersResponse FromEntity(List<Customer> customers)
    {
        List<CustomerResponse> customerResponses = customers
            .Select(customer => new CustomerResponse
            {
                CustomerID = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.Email
            })
            .ToList();

        return new GetAllCustomersResponse()
        {
            Customers = customerResponses
        };
    }
}