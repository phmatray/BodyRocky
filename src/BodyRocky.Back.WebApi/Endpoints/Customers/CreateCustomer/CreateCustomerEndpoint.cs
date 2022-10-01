using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Endpoints.Customers.GetCustomer;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.CreateCustomer;

public class CreateCustomerEndpoint
    : Endpoint<CreateCustomerRequest, CustomerResponse, CreateCustomerMapper>
{
    private readonly CustomerRepository _repository;

    public CreateCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateCustomerRequest req,
        CancellationToken ct)
    {
        Customer customer = Map.ToEntity(req);
        customer = await _repository.InsertAsync(customer);

        var response = Map.FromEntity(customer);

        await SendCreatedAtAsync<GetCustomerEndpoint>(
            "vaitefouderch",
            response,
            Http.GET,
            cancellation: ct);
    }
}
