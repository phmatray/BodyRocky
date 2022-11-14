using BodyRocky.Shared;
using BodyRocky.Shared.Forms;

namespace BodyRocky.Front.WebApp.Services.Contracts;

public interface IAuthorizeApi
{
    Task Login(LoginParameters loginParameters);
    Task Register(RegisterParameters registerParameters);
    Task Logout();
    Task<UserInfo> GetUserInfo();
}