namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Product
{
    public Guid ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal ProductPrice { get; set; } = default!;
    public string ProductURL { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}