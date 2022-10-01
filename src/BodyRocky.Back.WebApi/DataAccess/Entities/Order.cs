namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Order
{
    public Guid OrderID { get; set; } = default!;
    public string BillingName { get; set; } = default!;
    public string Reference { get; set; } = default!;
    public string DeliveryName { get; set; } = default!;
    public DateTime PurchaseDate { get; set; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
}