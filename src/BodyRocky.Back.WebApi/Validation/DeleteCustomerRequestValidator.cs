using BodyRocky.Core.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace BodyRocky.Back.WebApi.Validation;

public class DeleteCustomerRequestValidator : Validator<DeleteCustomerRequest>
{
    public DeleteCustomerRequestValidator()
    {
        RuleFor(x => x.CustomerID)
            .Must(s => Guid.TryParse((string?)s, out Guid _))
            .WithMessage("Customer ID must be a guid!");
    }
}