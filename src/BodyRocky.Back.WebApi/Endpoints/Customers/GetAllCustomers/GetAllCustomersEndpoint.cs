using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Requests.CustomerRequests;
using BodyRocky.Core.Contracts.Responses.CustomerResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Customers.GetAllCustomers;

public class GetAllCustomersEndpoint
    : Endpoint<GetAllCustomersRequest, GetAllCustomersResponse, GetAllCustomersMapper>
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

    public override async Task HandleAsync(GetAllCustomersRequest req, CancellationToken ct)
    {
        List<Customer> customers = await _repository.GetAllAsync(req.Skip, req.Take);
        GetAllCustomersResponse response = Map.FromEntity(customers);
        await SendOkAsync(response, ct);
    }
}