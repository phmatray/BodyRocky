using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Catalog.GetAllProducts;

public class GetAllProductsEndpoint
    : EndpointWithoutRequest<GetAllProductsResponse, GetAllProductsMapper>
{
    private readonly CatalogService _catalogService;

    public GetAllProductsEndpoint(CatalogService catalogService)
    {
        _catalogService = catalogService;
    }
    
    public override void Configure()
    {
        Get("/catalog/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<Product> products = await _catalogService.GetProductsAsync();
        GetAllProductsResponse response = Map.FromEntity(products);
        await SendOkAsync(response, ct);
    }
}