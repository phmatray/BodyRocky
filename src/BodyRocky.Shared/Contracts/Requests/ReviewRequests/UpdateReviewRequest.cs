namespace BodyRocky.Shared.Contracts.Requests;

public class UpdateReviewRequest
{
    public Guid ReviewID { get; init; } = default!;
    public int ReviewRating { get; init; } = default!;
    public string ReviewText { get; init; } = default!;
}