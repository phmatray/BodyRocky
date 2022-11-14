using BodyRocky.Shared.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace BodyRocky.Back.Server.Validation;

public class GetCustomerRequestValidator : Validator<GetCustomerRequest>
{
    public GetCustomerRequestValidator()
    {
        RuleFor(x => x.CustomerID)
            .Must(s => Guid.TryParse(s, out Guid _))
            .WithMessage("Customer ID must be a guid!");
    }
}