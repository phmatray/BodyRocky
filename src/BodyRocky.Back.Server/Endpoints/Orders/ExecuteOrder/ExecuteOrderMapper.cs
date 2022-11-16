using FastEndpoints;
using Order = BodyRocky.Back.Server.DataAccess.Entities.Order;

namespace BodyRocky.Back.Server.Endpoints.Orders.ExecuteOrder;

public class ExecuteOrderMapper
    : ResponseMapper<ExecuteOrderResponse, Order>
{
    public override ExecuteOrderResponse FromEntity(Order order)
    {
        return new ExecuteOrderResponse
        {
            OrderID = order.OrderID
        };
    }
}