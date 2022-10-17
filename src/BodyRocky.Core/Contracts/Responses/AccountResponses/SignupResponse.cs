namespace BodyRocky.Core.Contracts.Responses.AccountResponses;

public class SignupResponse
{
    public bool IsSuccessfulRegistration { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}