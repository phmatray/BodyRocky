namespace BodyRocky.Shared;

public class UserInfoResponse
{
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
    public Dictionary<string, string> ExposedClaims { get; set; }
}