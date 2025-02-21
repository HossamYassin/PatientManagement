using Microsoft.Data.SqlClient;
using PatientManagement.Application.Contracts;
using PatientManagement.Domain.Entities;
using PatientManagement.Infrastructure.Helpers;

namespace PatientManagement.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddAsync(Patient patient)
        {
            string encryptedEmail = EncryptionHelper.Encrypt(patient.Email);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Patients (Email, FullName, DateOfBirth, Street, City, State, ZipCode)
                             VALUES (@Email, @FullName, @DateOfBirth, @Street, @City, @State, @ZipCode);
                             SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", encryptedEmail);
                command.Parameters.AddWithValue("@FullName", patient.FullName);
                command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@Street", patient.Street);
                command.Parameters.AddWithValue("@City", patient.City);
                command.Parameters.AddWithValue("@State", patient.State);
                command.Parameters.AddWithValue("@ZipCode", patient.ZipCode);

                await connection.OpenAsync();
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Patients WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Patient
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Email = EncryptionHelper.Decrypt(reader.GetString(reader.GetOrdinal("Email"))),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            Street = reader.GetString(reader.GetOrdinal("Street")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"))
                        };
                    }
                }
            }
            return null;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Patients";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        patients.Add(new Patient
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Email = EncryptionHelper.Decrypt(reader.GetString(reader.GetOrdinal("Email"))),
                            FullName = reader.GetString(reader.GetOrdinal("FullName")),
                            DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                            Street = reader.GetString(reader.GetOrdinal("Street")),
                            City = reader.GetString(reader.GetOrdinal("City")),
                            State = reader.GetString(reader.GetOrdinal("State")),
                            ZipCode = reader.GetString(reader.GetOrdinal("ZipCode"))
                        });
                    }
                }
            }
            return patients;
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            string encryptedEmail = EncryptionHelper.Encrypt(patient.Email);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Patients 
                         SET Email = @Email, 
                             FullName = @FullName, 
                             DateOfBirth = @DateOfBirth, 
                             Street = @Street, 
                             City = @City, 
                             State = @State, 
                             ZipCode = @ZipCode
                         WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", patient.Id);
                command.Parameters.AddWithValue("@Email", encryptedEmail);
                command.Parameters.AddWithValue("@FullName", patient.FullName);
                command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@Street", patient.Street);
                command.Parameters.AddWithValue("@City", patient.City);
                command.Parameters.AddWithValue("@State", patient.State);
                command.Parameters.AddWithValue("@ZipCode", patient.ZipCode);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Patients WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

    }
}
