using BodyRocky.Core.Contracts.Responses.CustomerResponses;

namespace BodyRocky.Core.Contracts.Responses.AccountResponses;

public class LoginResponse
{
    public bool IsSuccessfulLogin { get; set; }
    public string? Token { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    public DateTime Expiration { get; set; }
    public CustomerResponse Customer { get; set; }
}