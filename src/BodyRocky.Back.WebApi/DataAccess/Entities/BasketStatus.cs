namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class BasketStatus
{
    public int Code { get; set; }
    public string Description { get; set; } = default!;
    
    // relation baskets
    public IList<Basket> Baskets { get; set; }
    
    public bool ValidateEntity()
    {
        return true;
    }
}