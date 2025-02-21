using MediatR;
using AutoMapper;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Queries;

namespace PatientManagement.Application.Features.Patients.Handlers
{
    public class GetPatientsCommandHandler : IRequestHandler<GetPatientsQuery, List<PatientDto>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientsCommandHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<List<PatientDto>>(patients);
        }
    }
}
