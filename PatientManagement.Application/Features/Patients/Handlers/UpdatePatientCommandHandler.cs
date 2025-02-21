using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Handlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, bool>
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                Id = request.Id,
                Email = request.Email,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                Street = request.Street,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode
            };

            return await _patientRepository.UpdateAsync(patient);
        }
    }
}
