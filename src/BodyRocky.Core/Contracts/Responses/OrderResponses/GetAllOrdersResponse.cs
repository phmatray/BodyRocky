namespace BodyRocky.Core.Contracts.Responses.AddressResponses.OrderResponses;

public class GetAllOrdersResponse
{
    public IEnumerable<OrderResponse> Orders { get; init; } = Enumerable.Empty<OrderResponse>();
}