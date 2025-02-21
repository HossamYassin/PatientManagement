using MediatR;
using PatientManagement.Application.DTOs;

namespace PatientManagement.Application.Features.Patients.Commands
{
    public class UpdatePatientCommand : IRequest<bool>
    {
        public PatientDto Patient { get; }

        public UpdatePatientCommand(PatientDto patient) => Patient = patient;
    }
}
