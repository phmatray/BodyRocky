namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class BasketProduct
{
    public int Quantity { get; set; }

    public Guid BasketId { get; set; }
    public Basket Basket { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}