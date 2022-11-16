namespace BodyRocky.Shared.Contracts.Responses;

public class BasketResponse
{
    public Guid BasketID { get; set; } = default!;
    public DateTime BasketDateAdded { get; set; } = default!;
    public BasketItem[] BasketItems { get; set; } 
}