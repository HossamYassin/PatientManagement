using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Application.Behaviors;
using System.Reflection;

namespace PatientManagement.Application.DependencyInjection
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register Validation Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
