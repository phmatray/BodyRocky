using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.UpdateCustomer;

public class UpdateCustomerEndpoint
    : Endpoint<UpdateCustomerRequest, CustomerDetailsResponse, CustomerMapper>
{
    private readonly CustomerRepository _repository;

    public UpdateCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Put("/crud/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        UpdateCustomerRequest req,
        CancellationToken ct)
    {
        Customer? existingCustomer = await _repository.GetByIDAsync(req.CustomerID);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        existingCustomer.FirstName = req.FirstName;
        existingCustomer.LastName = req.LastName;
        existingCustomer.BirthDate = req.BirthDate;
        existingCustomer.PhoneNumber = req.PhoneNumber;
        existingCustomer.Email = req.EmailAddress;
        
        await _repository.UpdateAsync(existingCustomer);
        
        CustomerDetailsResponse response = Map.FromEntity(existingCustomer);
        
        await SendOkAsync(response, ct);
    }
}
