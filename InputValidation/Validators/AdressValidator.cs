using FluentValidation;
using InputValidation.Models;

namespace InputValidation.Validators;

internal sealed class AdressValidator : AbstractValidator<Adress>
{
    public AdressValidator()
    {
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required");
        
        RuleFor(x=>x.Street)
            .NotEmpty().WithMessage("Street is required");
        
        RuleFor(x=>x.HouseNumber)
            .GreaterThan(0).WithMessage("House number must be greater than 0");
    }
}