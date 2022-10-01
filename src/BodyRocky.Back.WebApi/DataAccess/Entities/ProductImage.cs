namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class ProductImage
{
    public Guid ProductImageID { get; set; } = default!;
    public string Image { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}