using BodyRocky.Shared.Forms;

namespace BodyRocky.Shared;

public interface IAuthorizeApi
{
    Task Login(LoginParameters loginParameters);
    Task Logout();
    Task Register(RegisterParameters registerParameters);
    Task<UserInfoResponse> GetUserInfo();
}