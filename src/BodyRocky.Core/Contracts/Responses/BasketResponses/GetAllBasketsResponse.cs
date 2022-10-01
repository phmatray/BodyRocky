namespace BodyRocky.Core.Contracts.Responses.BasketResponses;

public class GetAllBasketsResponse
{
    public IEnumerable<BasketResponse> Baskets { get; init; } = Enumerable.Empty<BasketResponse>();
}