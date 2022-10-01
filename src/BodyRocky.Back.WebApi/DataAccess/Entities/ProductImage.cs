namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class ProductImage
{
    public Guid ProductImageID { get; init; } = default!;
    public string Image { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}