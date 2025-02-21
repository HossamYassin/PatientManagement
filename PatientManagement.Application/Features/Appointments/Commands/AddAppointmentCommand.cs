using MediatR;
using PatientManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Features.Appointments.Commands
{
    public class AddAppointmentCommand : IRequest<int>
    {
        public AppointmentDto Appointment { get; }
        public AddAppointmentCommand(AppointmentDto appointment) => Appointment = appointment;
    }
}
