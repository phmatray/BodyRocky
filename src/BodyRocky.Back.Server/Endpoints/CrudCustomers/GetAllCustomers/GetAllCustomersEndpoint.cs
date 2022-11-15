using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Back.Server.DataAccess.Repositories;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.CrudCustomers.GetAllCustomers;

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
        Get("/crud/customers");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllCustomersRequest req, CancellationToken ct)
    {
        List<Customer> customers = await _repository.GetAllAsync(req.Skip, req.Take);
        GetAllCustomersResponse response = Map.FromEntity(customers);
        await SendOkAsync(response, ct);
    }
}