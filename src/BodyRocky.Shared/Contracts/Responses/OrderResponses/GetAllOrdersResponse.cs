namespace BodyRocky.Shared.Contracts.Responses;

public class GetAllOrdersResponse
{
    public IEnumerable<OrderResponse> Orders { get; init; } = Enumerable.Empty<OrderResponse>();
}