namespace BodyRocky.Core.Contracts.Responses;

public class GetAllReviewsResponse
{
    public IEnumerable<ReviewResponse> Reviews { get; init; } = Enumerable.Empty<ReviewResponse>();
}