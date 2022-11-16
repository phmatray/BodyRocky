using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;
using Order = BodyRocky.Back.Server.DataAccess.Entities.Order;

namespace BodyRocky.Back.Server.Endpoints.Orders.ExecuteOrder;

public class ExecuteOrderEndpoint
    : Endpoint<ExecuteOrderRequest, ExecuteOrderResponse, ExecuteOrderMapper>
{
    private readonly OrderService _orderService;
    
    public ExecuteOrderEndpoint(OrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Post("orders/execute");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ExecuteOrderRequest req, CancellationToken ct)
    {
        Order order = await _orderService.ExecuteOrderAsync(req.BasketID);
        ExecuteOrderResponse response = Map.FromEntity(order);
        await SendOkAsync(response, ct);
    }
}