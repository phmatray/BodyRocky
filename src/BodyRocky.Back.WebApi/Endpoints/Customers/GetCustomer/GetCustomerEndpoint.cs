using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.GetCustomer;

public class GetCustomerEndpoint
    : Endpoint<GetCustomerRequest, CustomerResponse, CustomerMapper>
{
    private readonly CustomerRepository _repository;

    public GetCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/customers/{customerID}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetCustomerRequest req,
        CancellationToken ct)
    {
        bool isIDGuid = Guid.TryParse(req.CustomerID, out Guid customerID);

        if (!isIDGuid)
        {
            throw new Exception("customerID is not a valid GUID");
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