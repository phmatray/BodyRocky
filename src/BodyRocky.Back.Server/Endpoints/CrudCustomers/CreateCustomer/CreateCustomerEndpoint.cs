using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Back.Server.Endpoints.CrudCustomers.GetCustomer;
using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.CreateCustomer;

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
        Post("/crud/customers");
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
            "/crud/customers/{id}",
            response,
            Http.GET,
            cancellation: ct);
    }
}
