namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class ProductCategory
{
    public Guid ProductID { get; set; }
    public Product Product { get; set; }
    
    public Guid CategoryID { get; set; }
    public Category Category { get; set; }
}