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
                Id = request.Patient.Id,
                Email = request.Patient.Email,
                FullName = request.Patient.FullName,
                DateOfBirth = request.Patient.DateOfBirth,
                Street = request.Patient.Street,
                City = request.Patient.City,
                State = request.Patient.State,
                ZipCode = request.Patient.ZipCode
            };

            return await _patientRepository.UpdateAsync(patient);
        }
    }
}
