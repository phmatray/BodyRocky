namespace BodyRocky.Core.Contracts.Responses.AddressResponses.ReviewResponses;

public class GetAllReviewsResponse
{
    public IEnumerable<ReviewResponse> Reviews { get; init; } = Enumerable.Empty<ReviewResponse>();
}