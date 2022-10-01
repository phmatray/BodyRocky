namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Category
{
    public Guid CategoryID { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public bool IsFeatured { get; set; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
}