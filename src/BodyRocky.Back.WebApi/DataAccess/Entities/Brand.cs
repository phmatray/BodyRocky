namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Brand
{
    public Guid BrandID { get; set; } = default!;
    public string BrandName { get; set; } = default!;
    public string BrandLogo { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}

