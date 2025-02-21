using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Contracts
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetByPatientIdAsync(int patientId);
        Task<Appointment> GetByIdAsync(int id);
        Task<int> AddAsync(Appointment appointment);
    }
}
