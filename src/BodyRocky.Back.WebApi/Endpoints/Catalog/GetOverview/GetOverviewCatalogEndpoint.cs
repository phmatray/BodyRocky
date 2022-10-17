using BodyRocky.Back.WebApi.Services;
using BodyRocky.Core.Contracts.Responses.CatalogResponses;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints.Catalog.GetOverview;

public class GetOverviewCatalogEndpoint
    : EndpointWithoutRequest<GetOverviewCatalogResponse, GetOverviewCatalogMapper>
{
    private readonly CatalogService _catalogService;
    
    public GetOverviewCatalogEndpoint(CatalogService catalogService)
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
        CatalogOverview catalog = await _catalogService.GetOverviewAsync();
        GetOverviewCatalogResponse response = Map.FromEntity(catalog);
        await SendOkAsync(response, ct);
    }
}