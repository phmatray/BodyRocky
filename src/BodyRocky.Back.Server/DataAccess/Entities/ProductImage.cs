namespace BodyRocky.Back.Server.DataAccess.Entities;

public class ProductImage
{
    public Guid ProductImageID { get; set; } = default!;
    public string Image { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    
    // relation product
    public Guid ProductID { get; set; }
    public Product Product { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}