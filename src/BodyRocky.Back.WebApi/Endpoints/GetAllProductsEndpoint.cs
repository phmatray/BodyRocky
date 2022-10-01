using BodyRocky.Back.WebApi.DataAccess.Entities;
using FastEndpoints;

namespace BodyRocky.Back.WebApi.Endpoints;

public class GetAllProductsEndpoint
    : EndpointWithoutRequest<List<Product>>
{
    public override void Configure()
    {
        Post("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = new List<Product>
        {
            new Product
            {
                ProductId = Guid.NewGuid(),
                ProductDescription = "Une description",
                ProductName = "NomDeProduit",
                ProductPrice = 100m,
                ProductURL = "/products/1",
                IsFeatured = false
            }
        };

        await SendOkAsync(products, ct);
    }
}