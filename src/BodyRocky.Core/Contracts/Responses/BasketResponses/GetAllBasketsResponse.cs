namespace BodyRocky.Core.Contracts.Responses.AddressResponses.BasketResponses;

public class GetAllBasketsResponse
{
    public IEnumerable<BasketResponse> Baskets { get; init; } = Enumerable.Empty<BasketResponse>();
}