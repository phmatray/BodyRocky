namespace BodyRocky.Core.Contracts.Data;

public class BasketDTO
{
    public Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
}