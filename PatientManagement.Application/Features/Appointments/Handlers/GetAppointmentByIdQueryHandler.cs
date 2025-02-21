using AutoMapper;
using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Appointments.Queries;

namespace PatientManagement.Application.Features.Appointments.Handlers
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentDto?>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetAppointmentByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto?> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
            return appointment == null ? null : _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
