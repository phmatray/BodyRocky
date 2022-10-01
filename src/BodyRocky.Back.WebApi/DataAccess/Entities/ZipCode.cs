namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class ZipCode
{
    public int Code { get; init; } = default!;
    public string Commune { get; init; } = default!;
    public bool ValidateEntity()
    {
        return true;
    }
}