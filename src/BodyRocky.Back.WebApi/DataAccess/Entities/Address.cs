namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Address
{
    public Guid AddressID { get; init; } = default!;
    public DateTime AddressFromDate { get; init; } = default!;
    public DateTime AddressToDate { get; init; } = default!;
    public string Street { get; init; } = default!;

    public bool ValidateEntity()
    {
        return true;
    }
}