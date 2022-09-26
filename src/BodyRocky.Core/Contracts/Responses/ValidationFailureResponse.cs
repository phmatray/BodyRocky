namespace BodyRocky.Core.Contracts.Responses.AddressResponses;

public class ValidationFailureResponse
{
    public List<string> Errors { get; init; } = new();
}