namespace BodyRocky.Back.Server.DataAccess.Entities;

public class ZipCode
{
    public Guid ZipCodeID { get; set; } = default!;
    public int Code { get; set; } = default!;
    public string Commune { get; set; } = default!;
    
    // relation addresses
    public IList<Address> Addresses { get; set; }

    public bool ValidateEntity()
    {
        return true;
    }
}