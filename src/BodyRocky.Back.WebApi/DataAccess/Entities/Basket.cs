namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Basket
{
    public Guid BasketID { get; init; } = default!;
    public DateTime BasketDateAdded { get; init; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}

