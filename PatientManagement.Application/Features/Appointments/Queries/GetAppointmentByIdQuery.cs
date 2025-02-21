using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Appointments.Queries
{
    public class GetAppointmentByIdQuery : IRequest<AppointmentDto?>
    {
        public int Id { get; }
        public GetAppointmentByIdQuery(int id) => Id = id;
    }
}
