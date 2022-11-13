using BodyRocky.Back.WebApi.Services;
using BodyRocky.Core.Contracts.Responses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetOverview;

public class GetCatalogOverviewEndpoint
    : EndpointWithoutRequest<GetCatalogOverviewResponse, GetCatalogOverviewMapper>
{
    private readonly CatalogService _catalogService;
    
    public GetCatalogOverviewEndpoint(CatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public override void Configure()
    {
        Get("/catalog/overview");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        CatalogOverview catalog = await _catalogService.GetCatalogOverviewAsync();
        GetCatalogOverviewResponse response = Map.FromEntity(catalog);
        await SendOkAsync(response, ct);
    }
}