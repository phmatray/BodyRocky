namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Basket
{
    public Guid BasketID { get; set; } = default!;
    public DateTime BasketDateAdded { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}

