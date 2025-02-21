using MediatR;
using PatientManagement.Application.DTOs;
using System.Collections.Generic;

namespace PatientManagement.Application.Features.Patients.Queries
{
    public class GetPatientsQuery : IRequest<List<PatientDto>> { }
}
