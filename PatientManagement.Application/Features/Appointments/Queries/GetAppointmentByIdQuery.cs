using MediatR;
using PatientManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Features.Appointments.Queries
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentDto?>
    {
        public int Id { get; }
        public GetAppointmentByIdQuery(int id) => Id = id;
    }
}
