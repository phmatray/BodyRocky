namespace BodyRocky.Core.Contracts.Responses;

public class OrderResponse
{
    public Guid OrderID { get; init; } = default!;
    public string BillingName { get; init; } = default!;
    public string Reference { get; init; } = default!;
    public string DeliveryName { get; init; } = default!;
    public DateTime PurchaseDate { get; init; } = default!;
}