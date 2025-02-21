using FluentValidation;
using PatientManagement.Application.Features.Appointments.Commands;

namespace PatientManagement.Application.Validators
{
    public class AddAppointmentCommandValidator : AbstractValidator<AddAppointmentCommand>
    {
        public AddAppointmentCommandValidator()
        {
            RuleFor(x => x.Appointment.PatientId)
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0");

            RuleFor(x => x.Appointment.AppointmentDate)
                .NotEmpty().WithMessage("Appointment Date is required")
                .GreaterThan(DateTime.Now).WithMessage("Appointment Date must be in the future");

            RuleFor(x => x.Appointment.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must be less than 500 characters");
        }
    }
}
