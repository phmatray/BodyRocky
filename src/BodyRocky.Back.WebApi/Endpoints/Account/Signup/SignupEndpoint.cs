using BodyRocky.Back.WebApi.DataAccess.Entities;
using BodyRocky.Core.Contracts.Requests.AccountRequests;
using BodyRocky.Core.Contracts.Responses.AccountResponses;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.WebApi.Endpoints.Account.Signup;

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
    
