namespace BodyRocky.Core.Contracts.Responses;

public class GetAllOrdersResponse
{
    public IEnumerable<OrderResponse> Orders { get; init; } = Enumerable.Empty<OrderResponse>();
}