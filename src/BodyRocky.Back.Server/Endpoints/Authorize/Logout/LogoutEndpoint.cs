using BodyRocky.Back.Server.DataAccess.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.Server.Endpoints.Authorize.Logout;

public class LogoutEndpoint
    : EndpointWithoutRequest
{
    private readonly SignInManager<Customer> _signInManager;
    
    public LogoutEndpoint(
        SignInManager<Customer> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public override void Configure()
    {
        Post("/authorize/logout");
    }
    
    public override async Task HandleAsync(
        CancellationToken ct)
    {
        await _signInManager.SignOutAsync();
        await SendOkAsync(ct);
    }
}