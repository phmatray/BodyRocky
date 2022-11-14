namespace BodyRocky.Back.Server.DataAccess.Entities;

public class Category
{
    public Guid CategoryID { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public string CategoryImage { get; set; } = default!;
    public string CategoryIcon { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    
    // relation product
    public IList<ProductCategory> ProductCategories { get; set; }

    public bool ValidateEntity()
    {
        return true;
    }
}