namespace BodyRocky.Shared.Contracts.Responses;

public class GetOneBasketResponse
{
    public Guid BasketID { get; init; }
    public string BasketStatus { get; init; } = String.Empty;
    public DateTime BasketDateAdded { get; init; } = DateTime.Now;
    public List<BasketItem> Products { get; init; } = new();
}