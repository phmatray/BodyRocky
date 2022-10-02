namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class ProductCategory
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}