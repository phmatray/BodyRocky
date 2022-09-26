namespace BodyRocky.Core.Contracts.Requests.BasketRequests;

public class UpdateBasketRequest
{
    Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}