using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Core.Contracts.Responses.AddressResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Addresses.GetAll;

public class GetAllAddressEndpoint
    : EndpointWithoutRequest<GetAllAddressResponse, GetAllAddressMapper>
{
    private readonly AddressRepository _repository;

    public GetAllAddressEndpoint(AddressRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/addresses");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var addresses = await _repository.GetAllAsync();
        var response = Map.FromEntity(addresses);
        await SendOkAsync(response, ct);
    }
}