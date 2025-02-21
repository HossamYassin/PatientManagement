using MediatR;

namespace PatientManagement.Application.Features.Patients.Commands
{
    public class UpdatePatientCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
