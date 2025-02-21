using MediatR;

namespace PatientManagement.Application.Features.Patients.Commands
{
    public class DeletePatientCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
