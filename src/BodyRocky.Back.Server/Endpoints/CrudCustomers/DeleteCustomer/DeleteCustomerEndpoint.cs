using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.DeleteCustomer;

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
        Delete("/crud/customers/{customerID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        DeleteCustomerRequest req,
        CancellationToken ct)
    {
        bool isIDGuid = Guid.TryParse(req.CustomerID, out Guid customerID);

        if (!isIDGuid)
        {
            ThrowError("customerID is not a valid GUID");
        }
        
        await _repository.DeleteAsync(customerID);
        await SendOkAsync(ct);
    }
}