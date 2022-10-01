using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.GetAll;

public class GetAllCustomersEndpoint
    : EndpointWithoutRequest<GetAllCustomersResponse, GetAllCustomersMapper>
{
    private readonly CustomerRepository _repository;

    public GetAllCustomersEndpoint(CustomerRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var customers = await _repository.GetAllAsync();
        var response = Map.FromEntity(customers);
        await SendOkAsync(response, ct);
    }
}