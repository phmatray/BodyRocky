namespace BodyRocky.Shared.Contracts.Responses;

public class SignupResponse
{
    public bool IsSuccessfulRegistration { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}