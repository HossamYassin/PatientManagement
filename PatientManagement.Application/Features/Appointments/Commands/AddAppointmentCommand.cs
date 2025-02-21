using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Appointments.Commands
{
    public class AddAppointmentCommand : IRequest<int>
    {
        public AppointmentDto Appointment { get; }
        public AddAppointmentCommand(AppointmentDto appointment) => Appointment = appointment;
    }
}
