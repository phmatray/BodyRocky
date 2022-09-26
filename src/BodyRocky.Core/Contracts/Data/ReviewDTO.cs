namespace BodyRocky.Core.Contracts.Data;

public class ReviewDTO
{
    public Guid ReviewID { get; init; } = default!;
    public int ReviewRating { get; init; } = default!;
    public string ReviewText { get; init; } = default!;
}