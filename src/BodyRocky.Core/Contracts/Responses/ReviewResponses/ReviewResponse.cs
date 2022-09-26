namespace BodyRocky.Core.Contracts.Responses.AddressResponses.ReviewResponses;

public class ReviewResponse
{
    public Guid ReviewID { get; init; } = default!;
    public int ReviewRating { get; init; } = default!;
    public string ReviewText { get; init; } = default!;
}