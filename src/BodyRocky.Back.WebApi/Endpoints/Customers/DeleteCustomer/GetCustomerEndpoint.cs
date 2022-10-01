using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.DeleteCustomer;

public class DeleteCustomerEndpoint
    : Endpoint<DeleteCustomerRequest>
{
    private readonly CustomerRepository _repository;

    public DeleteCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Delete("/customers/{CustomerId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteCustomerRequest req,
        CancellationToken ct)
    {
        bool isIdGuid = Guid.TryParse(req.CustomerID, out Guid customerId);

        if (!isIdGuid)
        {
            throw new Exception("customerId is not a valid GUID");
        }
        
        await _repository.DeleteAsync(customerId);
        await SendOkAsync(ct);
    }
}