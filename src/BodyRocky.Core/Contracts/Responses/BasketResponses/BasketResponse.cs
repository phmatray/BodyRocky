namespace BodyRocky.Core.Contracts.Responses;

public class BasketResponse
{
    public Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
    public List<BasketItemResponse> BasketItems { get; set; } = new();
}