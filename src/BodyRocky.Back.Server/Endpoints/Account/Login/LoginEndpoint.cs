using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BodyRocky.Back.Server.DataAccess.Entities;
using BodyRocky.Shared.Contracts.Requests;
using BodyRocky.Shared.Contracts.Responses;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BodyRocky.Back.Server.Endpoints.Account.Login;


public class LoginEndpoint
    : Endpoint<LoginRequest, LoginResponse>
{
    private readonly UserManager<Customer> _userManager;
    
    public LoginEndpoint(UserManager<Customer> userManager)
    {
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("/accounts/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        Customer? user = _userManager.FindByEmailAsync(req.Email).Result;
        if (user == null)
        {
            throw new Exception("User not found");
        }

        bool result = _userManager.CheckPasswordAsync(user, req.Password).Result;
        if (!result)
        {
            throw new Exception("Invalid password");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes("super secret key");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        string? tokenString = tokenHandler.WriteToken(token);

        var loginResponse = new LoginResponse
        {
            IsSuccessfulLogin = true,
            Expiration = token.ValidTo,
            Token = tokenString,
            Customer = new CustomerDetailsResponse
            {
                CustomerID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.Email
            }
        };
        
        await SendOkAsync(loginResponse, ct);
    }

    private static LoginResponse GetWrongIdentifiersLoginResponse()
    {
        return new LoginResponse
        {
            IsSuccessfulLogin = false,
            Token = null,
            Errors = new List<string>
            {
                "The couple email/password is invalid"
            }
        };
    }
    
    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        if (Config == null)
        {
            throw new InvalidOperationException("Configuration is null");
        }
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: Config["JWT:ValidIssuer"],
            audience: Config["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}