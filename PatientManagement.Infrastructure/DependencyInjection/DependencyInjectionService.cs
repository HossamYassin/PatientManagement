using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Contracts;
using PatientManagement.Infrastructure.Repositories;

using Microsoft.Extensions.Configuration;

namespace PatientManagement.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Register repositories with connection string
            services.AddScoped<IPatientRepository>(sp => new PatientRepository(connectionString));
            services.AddScoped<IAppointmentRepository>(sp => new AppointmentRepository(connectionString));

            return services;
        }
    }
}
