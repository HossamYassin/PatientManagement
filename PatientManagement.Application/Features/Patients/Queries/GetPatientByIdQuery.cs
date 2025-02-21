using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries
{
    public class GetPatientByIdQuery : IRequest<PatientDto?>
    {
        public int Id { get; }
        public GetPatientByIdQuery(int id) => Id = id;
    }
}
