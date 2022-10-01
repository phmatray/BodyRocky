using BodyRocky.Back.WebApi.DataAccess.Repositories;
using BodyRocky.Back.WebApi.Endpoints.Baksets;
using BodyRocky.Core.Contracts.Responses.BasketResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Baskets.GetAll;

public class GetAllBasketsEndpoint
: EndpointWithoutRequest<GetAllBasketsResponse, GetAllBasketsMapper>
{
    private readonly BasketRepository _repository;

    public GetAllBasketsEndpoint(BasketRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Get("/baskets");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var baskets = await _repository.GetAllAsync();
        var response = Map.FromEntity(baskets);
        await SendOkAsync(response, ct);
    }
}