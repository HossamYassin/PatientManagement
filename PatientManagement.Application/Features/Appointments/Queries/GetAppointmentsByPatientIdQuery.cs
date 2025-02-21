using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Appointments.Queries
{
    public class GetAppointmentsByPatientIdQuery : IRequest<List<AppointmentDto>>
    {
        public int PatientId { get; set; }
        public GetAppointmentsByPatientIdQuery(int patientId) => PatientId = patientId;
    }
}
