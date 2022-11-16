using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;
using Order = BodyRocky.Back.Server.DataAccess.Entities.Order;

namespace BodyRocky.Back.Server.Endpoints.Orders.GetAllOrdersByCustomer;

public class GetAllOrdersByCustomerEndpoint
    : Endpoint<GetAllOrdersByCustomerRequest, GetAllOrdersByCustomerResponse, GetAllOrdersByCustomerMapper>
{
    private readonly OrderService _orderService;
    
    public GetAllOrdersByCustomerEndpoint(OrderService orderService)
    {
        _orderService = orderService;
    }

    public override void Configure()
    {
        Get("/orders/customer/{CustomerId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetAllOrdersByCustomerRequest req, CancellationToken ct)
    {
        List<Order> orders = await _orderService.GetOrdersByCustomerIDAsync(req.CustomerId);
        GetAllOrdersByCustomerResponse response = Map.FromEntity(orders);
        await SendOkAsync(response, ct);
    }
}