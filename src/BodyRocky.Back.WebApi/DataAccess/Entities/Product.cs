namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Product
{
    public Guid ProductId { get; init; } = default!;
    public string ProductName { get; init; } = default!;
    public string ProductDescription { get; init; } = default!;
    public decimal ProductPrice { get; init; } = default!;
    public string ProductURL { get; init; } = default!;
    public bool IsFeatured { get; init; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}