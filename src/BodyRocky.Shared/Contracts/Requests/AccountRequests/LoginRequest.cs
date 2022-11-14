namespace BodyRocky.Shared.Contracts.Requests;

public class LoginRequest
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}