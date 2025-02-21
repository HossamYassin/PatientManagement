using AutoMapper;
using MediatR;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.Features.Appointments.Commands;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Features.Appointments.Handlers
{
    public class AddAppointmentHandler : IRequestHandler<AddAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AddAppointmentHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointmentEntity = _mapper.Map<Appointment>(request.Appointment);
            return await _appointmentRepository.AddAsync(appointmentEntity);
        }
    }
}
