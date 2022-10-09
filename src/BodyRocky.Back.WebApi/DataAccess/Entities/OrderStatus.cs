namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class OrderStatus
{
    public int Code { get; set; }

    public string Description { get; set; } = default!;
    
    // relation orders
    public IList<Order> Orders { get; set; }
    
    public bool ValidateEntity()
    {
        return true;
    }
}