using FluentValidation;
using InputValidation.Models;

namespace InputValidation.Validators;

internal sealed class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        var minimalAge = 18;
        RuleFor(x=>x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required")
            .Must(BeInPast).WithMessage("DateOfBirth must be in the past")
            .Must(x=>BeMinumumAge(x,minimalAge)).WithMessage($"Age must be greater than {minimalAge}");


        RuleFor(x => x.Adress)
            .NotNull().WithMessage("Adress is required")
            .SetValidator(new AdressValidator());

    }

    private static bool BeInPast(DateTime date)
    {
        return date < DateTime.Today;
    }

    private static bool BeMinumumAge(DateTime date, int minimalAge)
    {
        return date.Year - DateTime.Now.Year - minimalAge > 0;
    }
}