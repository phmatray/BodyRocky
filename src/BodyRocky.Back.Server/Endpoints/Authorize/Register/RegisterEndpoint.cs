using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Forms;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.Server.Endpoints.Authorize.Register;

public class RegisterEndpoint
    : Endpoint<RegisterParameters>
{
    private readonly UserManager<Customer> _userManager;
    private readonly SignInManager<Customer> _signInManager;
    
    public RegisterEndpoint(
        UserManager<Customer> userManager,
        SignInManager<Customer> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public override void Configure()
    {
        Post("/authorize/register");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(
        RegisterParameters req,
        CancellationToken ct)
    {
        var user = new Customer
        {
            UserName = req.Email.Split("@").First(),
            Email = req.Email,
            FirstName = req.FirstName,
            LastName = req.LastName
        };
        
        var result = await _userManager.CreateAsync(user, req.Password);
        
        if (!result.Succeeded)
        {
            string message = 
                result.Errors.FirstOrDefault()?.Description
                ?? "Unknown error";
            
            ThrowError(message);
        }
        
        user = await _userManager.FindByEmailAsync(req.Email);
        
        if (user == null)
        {
            ThrowError("User does not exist");
        }
        
        var singInResult = await _signInManager.CheckPasswordSignInAsync(user, req.Password, false);
        
        if (!singInResult.Succeeded)
        {
            ThrowError("Invalid password");
        }

        await _signInManager.SignInAsync(user, false);

        await SendOkAsync(ct);
    }
}