using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.Server.Endpoints.Account.Signup;

public class SignupEndpoint
    : Endpoint<SignupRequest, SignupResponse>
{
    private readonly UserManager<Customer> _userManager;
    
    public SignupEndpoint(UserManager<Customer> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/accounts/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(
        SignupRequest req,
        CancellationToken ct)
    {
        var newCustomer = new Customer
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            UserName = req.Email,
            Email = req.Email
        };
        
        IdentityResult? user = await _userManager.CreateAsync(newCustomer, req.Password);
        
        if (!user.Succeeded)
        {
            foreach (IdentityError error in user.Errors)
            {
                AddError(error.Description);
            }
            
            ThrowIfAnyErrors();
        }

        SignupResponse response = user.Succeeded
            ? new SignupResponse
            {
                IsSuccessfulRegistration = true,
                Errors = new string[0]
            }
            : new SignupResponse
            {
                IsSuccessfulRegistration = false,
                Errors = user.Errors.Select(x => x.Description)
            };
        
        await SendOkAsync(response, ct);
    }
}
    
