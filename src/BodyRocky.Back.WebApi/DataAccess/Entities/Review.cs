namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Review
{
    public Guid ReviewID { get; init; } = default!;
    public int ReviewRating { get; init; } = default!;
    public string ReviewText { get; init; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}