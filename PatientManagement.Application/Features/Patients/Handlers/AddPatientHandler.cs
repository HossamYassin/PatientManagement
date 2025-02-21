using AutoMapper;
using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Patients.Handlers
{
    public class AddPatientHandler : IRequestHandler<AddPatientCommand, int>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public AddPatientHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = _mapper.Map<Patient>(request.Patient);
            return await _patientRepository.AddAsync(patientEntity);
        }
    }
}