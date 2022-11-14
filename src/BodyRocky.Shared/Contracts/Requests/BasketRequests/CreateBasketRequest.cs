namespace BodyRocky.Shared.Contracts.Requests;

public class CreateBasketRequest
{
    Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}