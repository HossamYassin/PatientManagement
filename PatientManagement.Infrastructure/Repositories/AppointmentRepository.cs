using Microsoft.Data.SqlClient;
using PatientManagement.Application.Contracts;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string _connectionString;

        public AppointmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Appointment>> GetByPatientIdAsync(int patientId)
        {
            var appointments = new List<Appointment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Appointments WHERE PatientId = @PatientId", connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            appointments.Add(new Appointment
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                AppointmentDate = reader.GetDateTime(2),
                                Description = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return appointments;
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            Appointment? appointment = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Appointments WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            appointment = new Appointment
                            {
                                Id = reader.GetInt32(0),
                                PatientId = reader.GetInt32(1),
                                AppointmentDate = reader.GetDateTime(2),
                                Description = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return appointment;
        }

        public async Task<int> AddAsync(Appointment appointment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand(
                    "INSERT INTO Appointments (PatientId, AppointmentDate, Description) " +
                    "VALUES (@PatientId, @AppointmentDate, @Description); " +
                    "SELECT SCOPE_IDENTITY();", connection))
                {
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }
    }
}
