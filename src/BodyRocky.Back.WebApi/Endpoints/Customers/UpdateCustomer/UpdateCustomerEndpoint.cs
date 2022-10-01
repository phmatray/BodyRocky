using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.UpdateCustomer;

public class UpdateCustomerEndpoint
    : Endpoint<UpdateCustomerRequest, CustomerResponse, CustomerMapper>
{
    private readonly CustomerRepository _repository;

    public UpdateCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Put("/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        UpdateCustomerRequest req,
        CancellationToken ct)
    {
        Customer? existingCustomer = await _repository.GetByIdAsync(req.CustomerID);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        existingCustomer.FirstName = req.FirstName;
        existingCustomer.LastName = req.LastName;
        existingCustomer.BirthDate = req.BirthDate;
        existingCustomer.PhoneNumber = req.PhoneNumber;
        existingCustomer.EmailAddress = req.EmailAddress;
        
        await _repository.UpdateAsync(existingCustomer);
        
        CustomerResponse response = Map.FromEntity(existingCustomer);
        
        await SendOkAsync(response, ct);
    }
}
