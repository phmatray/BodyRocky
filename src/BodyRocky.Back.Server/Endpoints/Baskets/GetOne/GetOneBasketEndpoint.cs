using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;

namespace BodyRocky.Back.Server.Endpoints.Baskets.GetOne;

public class GetOneBasketEndpoint
    : Endpoint<GetOneBasketRequest, GetOneBasketResponse, GetOneBasketMapper>
{
    private readonly BasketService _basketService;
    
    public GetOneBasketEndpoint(BasketService basketService)
    {
        _basketService = basketService;
    }

    public override void Configure()
    {
        Get("baskets/customer/{CustomerId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetOneBasketRequest req, CancellationToken ct)
    {
        Basket basket = await _basketService.GetBasketAsync(req.CustomerID);
        GetOneBasketResponse response = Map.FromEntity(basket);
        await SendOkAsync(response, ct);
    }
}