using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.GetCustomer;

public class GetCustomerEndpoint
    : Endpoint<GetCustomerRequest, CustomerDetailsResponse, CustomerMapper>
{
    private readonly CustomerRepository _repository;

    public GetCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/crud/customers/{customerID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetCustomerRequest req,
        CancellationToken ct)
    {
        bool isIDGuid = Guid.TryParse(req.CustomerID, out Guid customerID);

        if (!isIDGuid)
        {
            ThrowError("customerID is not a valid GUID");
        }
        
        var customers = await _repository.GetByIDAsync(customerID);

        if (customers is null)
        {
            await SendNotFoundAsync(ct);
        }
        else
        {
            var response = Map.FromEntity(customers);
            await SendOkAsync(response, ct);
        }
    }
}