namespace BodyRocky.Front.WebApp.Store.Models;

public record UserInfo(
    string Name,
    string AuthenticationType,
    bool IsAuthenticated,
    Guid UserId);