using Core.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseMethods<>), typeof(BaseMethods<>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<IMotorbikeRepo, MotorbikeRepo>();

            return services;
        }
    }
}
