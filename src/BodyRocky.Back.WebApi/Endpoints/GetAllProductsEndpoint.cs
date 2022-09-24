using BodyRocky.Core;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace BodyRocky.Back.WebApi.Endpoints;

[HttpGet("products"), AllowAnonymous]
public class GetAllProductsEndpoint
    : EndpointWithoutRequest<List<Product>>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Cordes"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Bandages"
            }
        };

        await SendOkAsync(products, ct);
    }
}