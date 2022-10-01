namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Brand
{
    public Guid BrandID { get; init; } = default!;
    public string BrandName { get; init; } = default!;
    public string BrandLogo { get; init; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}

