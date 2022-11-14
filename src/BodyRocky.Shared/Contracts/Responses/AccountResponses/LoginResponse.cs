namespace BodyRocky.Shared.Contracts.Responses;

public class LoginResponse
{
    public bool IsSuccessfulLogin { get; set; }
    public string Token { get; set; } = string.Empty;
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    public DateTime Expiration { get; set; }
    public CustomerDetailsResponse Customer { get; set; } = null!;
}