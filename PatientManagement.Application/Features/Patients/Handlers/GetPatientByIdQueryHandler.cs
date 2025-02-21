using AutoMapper;
using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Queries;

namespace PatientManagement.Application.Features.Patients.Handlers
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto?>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);
            return patient == null ? null : _mapper.Map<PatientDto>(patient);
        }
    }
}
