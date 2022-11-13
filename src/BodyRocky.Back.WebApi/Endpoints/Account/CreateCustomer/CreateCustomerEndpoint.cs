using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Endpoints.Account.GetCustomer;
using BodyRocky.Core.Contracts.Requests;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Account.CreateCustomer;

public class CreateCustomerEndpoint
    : Endpoint<CreateCustomerRequest, CustomerDetailsResponse, CreateCustomerMapper>
{
    private readonly CustomerRepository _repository;

    public CreateCustomerEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/accounts/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        CreateCustomerRequest req,
        CancellationToken ct)
    {
        Customer customer = Map.ToEntity(req);
        customer = await _repository.InsertAsync(customer);

        CustomerDetailsResponse response = Map.FromEntity(customer);

        await SendCreatedAtAsync<GetCustomerEndpoint>(
            "vaitefouderch",
            response,
            Http.GET,
            cancellation: ct);
    }
}
