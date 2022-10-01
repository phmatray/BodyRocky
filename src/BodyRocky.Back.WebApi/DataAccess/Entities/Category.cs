namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Category
{
    public Guid CategoryID { get; init; } = default!;
    public string CategoryName { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
}