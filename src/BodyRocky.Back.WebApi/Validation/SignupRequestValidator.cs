using BodyRocky.Core.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace BodyRocky.Back.WebApi.Validation;

public class SignupRequestValidator : Validator<SignupRequest>
{
    public SignupRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty();
        
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .Equal(x => x.Password);
    }
}