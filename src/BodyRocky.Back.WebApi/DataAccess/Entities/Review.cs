namespace BodyRocky.Back.WebApi.DataAccess.Entities;

public class Review
{
    public Guid ReviewID { get; set; } = default!;
    public int ReviewRating { get; set; } = default!;
    public string ReviewText { get; set; } = default!;
    
    public bool ValidateEntity()
    {
        return true;
    }
}