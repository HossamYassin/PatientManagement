using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Patients.Commands
{
    public class AddPatientCommand : IRequest<int>
    {
        public PatientDto Patient { get; }

        public AddPatientCommand(PatientDto patient) => Patient = patient;
    }
}
