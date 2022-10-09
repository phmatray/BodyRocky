namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Category
{
    public Guid CategoryID { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    
    // relation product
    public IList<ProductCategory> ProductCategories { get; set; }
    
    // relation children categories
    public Guid ParentCategoryID { get; set; } = default!;
    public Category ParentCategory { get; set; } = default!;
    public IList<Category> SubCategories { get; set; }

    public bool ValidateEntity()
    {
        return true;
    }
}