using FluentValidation;

namespace Motors.Application.Features.Vehicles.Commands;

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Brand is required and cannot exceed 50 characters");

        RuleFor(x => x.Model)
            .MaximumLength(50)
            .When(x => !string.IsNullOrEmpty(x.Model))
            .WithMessage("Model cannot exceed 50 characters");

        RuleFor(x => x.Date)
            .Must(date => date == null || date <= DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Manufacture date cannot be in the future");
    }
}