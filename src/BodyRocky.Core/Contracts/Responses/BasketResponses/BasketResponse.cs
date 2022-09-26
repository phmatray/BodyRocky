namespace BodyRocky.Core.Contracts.Responses.AddressResponses.BasketResponses;

public class BasketResponse
{
    public Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}