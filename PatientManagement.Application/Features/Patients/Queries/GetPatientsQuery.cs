using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Patients.Queries
{
    public class GetPatientsQuery : IRequest<List<PatientDto>> { }
}
