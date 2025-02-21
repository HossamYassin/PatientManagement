using MediatR;
using PatientManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Features.Appointments.Queries
{
    public class GetAppointmentsByPatientIdQuery : IRequest<List<AppointmentDto>>
    {
        public int PatientId { get; set; }
        public GetAppointmentsByPatientIdQuery(int patientId) => PatientId = patientId;
    }
}
