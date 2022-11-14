using BodyRocky.Back.Server.DataAccess.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace BodyRocky.Back.Server.Endpoints.Account.Me;

public class MeEndpoint
    : Endpoint<GetMeRequest, GetMeResponse>
{
    private readonly UserManager<Customer> _userManager;

    public MeEndpoint(UserManager<Customer> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Get("/accounts/me");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(GetMeRequest request, CancellationToken cancellationToken)
    {
    }
}

public class GetMeRequest
{
    [FromClaim]
    public string CustomerID { get; set; }
}

public class GetMeResponse
{
    public string CustomerID { get; set; }
}