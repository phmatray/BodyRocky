namespace BodyRocky.Back.Server.DataAccess.Entities;

public class BasketProduct
{
    public int Quantity { get; set; }

    public Guid BasketID { get; set; }
    public Basket Basket { get; set; }
    
    public Guid ProductID { get; set; }
    public Product Product { get; set; }
}