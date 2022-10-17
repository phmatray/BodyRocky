namespace BodyRocky.Core.Contracts.Requests.AccountRequests;

public class LoginRequest
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}