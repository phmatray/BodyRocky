namespace BodyRocky.Back.Server.DataAccess.Entities;

public class Brand
{
    public Guid BrandID { get; set; } = default!;
    public string BrandName { get; set; } = default!;
    public string BrandLogo { get; set; } = default!;

    // relation products
    public IList<Product> Products { get; set; }

    public bool ValidateEntity()
    {
        return true;
    }
}

