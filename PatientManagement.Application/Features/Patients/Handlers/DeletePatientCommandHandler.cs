using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.Features.Patients.Commands;

namespace PatientManagement.Application.Features.Patients.Handlers
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            return await _patientRepository.DeleteAsync(request.Id);
        }
    }
}
