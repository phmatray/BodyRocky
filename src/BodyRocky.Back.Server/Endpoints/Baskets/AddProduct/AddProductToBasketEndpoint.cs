using BodyRocky.Back.Server.Services;
using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Baskets.AddProduct;

public class AddProductToBasketEndpoint
    : Endpoint<AddProductToBasketRequest>
{
    private readonly BasketService _basketService;
    
    public AddProductToBasketEndpoint(BasketService basketService)
    {
        _basketService = basketService;
    }

    public override void Configure()
    {
        Post("/baskets/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddProductToBasketRequest req, CancellationToken ct)
    {
        await _basketService.AddProductToBasketAsync(req.CustomerId, req.ProductId, req.Quantity);
        await SendOkAsync(ct);
    }
}