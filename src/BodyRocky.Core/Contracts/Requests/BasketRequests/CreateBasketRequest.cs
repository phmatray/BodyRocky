namespace BodyRocky.Core.Contracts.Requests.BasketRequests;

public class CreateBasketRequest
{
    Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}