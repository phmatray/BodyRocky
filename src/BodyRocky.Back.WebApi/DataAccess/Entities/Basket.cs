namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Basket
{
    public Guid BasketID { get; set; } = default!;
    public DateTime BasketDateAdded { get; set; } = default!;
    
    // relation products
    public IList<BasketProduct> BasketProducts { get; set; } = new List<BasketProduct>();
    
    // relation basket status
    public int BasketStatusCode { get; set; }
    public BasketStatus BasketStatus { get; set; } = default!;
    
    // relation customer
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; } = default!;

    public bool ValidateEntity()
    {
        return true;
    }
}

