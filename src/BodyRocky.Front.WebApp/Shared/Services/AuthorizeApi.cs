using System.Net.Http.Json;
using BodyRocky.Shared;
using BodyRocky.Shared.Forms;

namespace BodyRocky.Front.WebApp.Shared.Services;

public class AuthorizeApi : IAuthorizeApi
{
    private readonly HttpClient _httpClient;

    public AuthorizeApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Login(LoginParameters loginParameters)
    {
        var result = await _httpClient.PostAsJsonAsync("authorize/Login", loginParameters);
        
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new Exception(await result.Content.ReadAsStringAsync());
        }
        
        result.EnsureSuccessStatusCode();
    }

    public async Task Logout()
    {
        var result = await _httpClient.PostAsync("authorize/Logout", null);
        result.EnsureSuccessStatusCode();
    }

    public async Task Register(RegisterParameters registerParameters)
    {
        //var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
        var result = await _httpClient.PostAsJsonAsync("authorize/Register", registerParameters);
        
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new Exception(await result.Content.ReadAsStringAsync());
        }
        
        result.EnsureSuccessStatusCode();
    }

    public async Task<UserInfoResponse?> GetUserInfo()
    {
        return await _httpClient.GetFromJsonAsync<UserInfoResponse>("authorize/UserInfo");
    }
}