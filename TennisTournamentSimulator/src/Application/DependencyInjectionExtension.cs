using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using Domain.Simulators;

namespace Application
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(GetAssembly());
            services.AddValidatorsFromAssembly(GetAssembly());
            services.AddMediatR(GetAssembly());

            services.AddSingleton<IMatchFactory, MatchFactory>();
            services.AddSingleton<ISimulator, Simulator>();
            
             return services;
        }

        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
