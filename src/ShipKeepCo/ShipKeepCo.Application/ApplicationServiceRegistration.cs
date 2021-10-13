using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShipKeepCo.Application.Behaviors;
using System.Reflection;

namespace ShipKeepCo.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            
            return services;
        }
    }
}
