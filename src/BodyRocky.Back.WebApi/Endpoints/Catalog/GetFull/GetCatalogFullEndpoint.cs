using BodyRocky.Back.WebApi.Services;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetFull;

public class GetCatalogFullEndpoint
    : EndpointWithoutRequest<GetCatalogFullResponse, GetCatalogFullMapper>
{
    private readonly CatalogService _catalogService;
    
    public GetCatalogFullEndpoint(CatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public override void Configure()
    {
        Get("/catalog/full");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        CatalogFull catalog = await _catalogService.GetCatalogFullAsync();
        GetCatalogFullResponse response = Map.FromEntity(catalog);
        await SendOkAsync(response, ct);
    }
}