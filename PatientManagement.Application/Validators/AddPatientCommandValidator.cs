using FluentValidation;
using PatientManagement.Application.Features.Patients.Commands;

namespace PatientManagement.Application.Validators
{
    public class AddPatientCommandValidator : AbstractValidator<AddPatientCommand>
    {
        public AddPatientCommandValidator()
        {
            RuleFor(x => x.Patient.FullName)
                .NotEmpty().WithMessage("Full Name is required")
                .MaximumLength(100).WithMessage("Full Name must be less than 100 characters");

            RuleFor(x => x.Patient.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Patient.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required")
                .LessThan(DateTime.UtcNow).WithMessage("Date of Birth must be in the past");

            RuleFor(x => x.Patient.Street)
                .NotEmpty().WithMessage("Street is required");

            RuleFor(x => x.Patient.City)
                .NotEmpty().WithMessage("City is required");

            RuleFor(x => x.Patient.State)
                .NotEmpty().WithMessage("State is required");

            RuleFor(x => x.Patient.ZipCode)
                .NotEmpty().WithMessage("Zip Code is required")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid Zip Code format");
        }
    }
}
