namespace BodyRocky.Core.Contracts.Requests.ReviewRequests;

public class CreateReviewRequest
{
    public Guid ReviewID { get; init; } = default!;
    public int ReviewRating { get; init; } = default!;
    public string ReviewText { get; init; } = default!;
}