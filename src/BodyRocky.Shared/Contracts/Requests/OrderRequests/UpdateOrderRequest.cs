namespace BodyRocky.Shared.Contracts.Requests;

public class UpdateOrderRequest
{
    public Guid OrderID { get; init; } = default!;
    public string BillingName { get; init; } = default!;
    public string Reference { get; init; } = default!;
    public string DeliveryName { get; init; } = default!;
    public DateTime PurchaseDate { get; init; } = default!;
}