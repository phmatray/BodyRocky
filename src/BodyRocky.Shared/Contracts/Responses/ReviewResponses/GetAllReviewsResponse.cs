namespace BodyRocky.Shared.Contracts.Responses;

public class GetAllReviewsResponse
{
    public IEnumerable<ReviewResponse> Reviews { get; init; } = Enumerable.Empty<ReviewResponse>();
}