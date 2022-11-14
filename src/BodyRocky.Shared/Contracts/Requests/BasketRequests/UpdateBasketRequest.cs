namespace BodyRocky.Shared.Contracts.Requests;

public class UpdateBasketRequest
{
    Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}