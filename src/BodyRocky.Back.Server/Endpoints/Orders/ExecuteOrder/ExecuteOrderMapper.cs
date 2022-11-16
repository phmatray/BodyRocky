namespace BodyRocky.Back.Server.Endpoints.Orders.ExecuteOrder;

public class ExecuteOrderMapper
    : FastEndpoints.ResponseMapper<ExecuteOrderResponse, Order>
{
    public override ExecuteOrderResponse FromEntity(Order order)
    {
        return new ExecuteOrderResponse
        {
            OrderID = order.OrderID
        };
    }
}