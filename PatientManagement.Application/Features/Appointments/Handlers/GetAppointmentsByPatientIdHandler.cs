using AutoMapper;
using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Appointments.Queries;

namespace PatientManagement.Application.Features.Appointments.Handlers
{
    public class GetAppointmentsByPatientIdHandler : IRequestHandler<GetAppointmentsByPatientIdQuery, List<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsByPatientIdHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> Handle(GetAppointmentsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetByPatientIdAsync(request.PatientId);
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
    }
}
