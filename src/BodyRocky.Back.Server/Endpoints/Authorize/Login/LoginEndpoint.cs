using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Forms;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.Server.Endpoints.Authorize.Login;

public class LoginEndpoint
    : Endpoint<LoginParameters>
{
    private readonly UserManager<Customer> _userManager;
    private readonly SignInManager<Customer> _signInManager;
    
    public LoginEndpoint(
        UserManager<Customer> userManager,
        SignInManager<Customer> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    public override void Configure()
    {
        Post("/authorize/login");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(
        LoginParameters req,
        CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        
        if (user == null)
        {
            ThrowError("User does not exist");
        }
        
        var singInResult = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);
        
        if (!singInResult.Succeeded)
        {
            ThrowError("Invalid password");
        }

        await _signInManager.SignInAsync(user, req.RememberMe);

        await SendOkAsync(ct);
    }
}