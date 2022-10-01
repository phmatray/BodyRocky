using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.GetCustomer;

public class GetCustomerEndpoint
    : Endpoint<GetCustomerRequest, CustomerResponse, GetCustomerMapper>
{
    private readonly CustomerRepository _repository;

    public GetCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/customers/{CustomerId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        GetCustomerRequest req,
        CancellationToken ct)
    {
        bool isIdGuid = Guid.TryParse(req.CustomerID, out Guid customerId);

        if (!isIdGuid)
        {
            throw new Exception("customerId is not a valid GUID");
        }
        
        var customers = await _repository.GetByIdAsync(customerId);

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