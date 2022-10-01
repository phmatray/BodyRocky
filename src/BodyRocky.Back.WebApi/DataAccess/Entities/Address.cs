namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Address
{
    public Guid AddressID { get; set; } = default!;
    public DateTime AddressFromDate { get; set; } = default!;
    public DateTime AddressToDate { get; set; } = default!;
    public string Street { get; set; } = default!;

    public bool ValidateEntity()
    {
        return true;
    }
}