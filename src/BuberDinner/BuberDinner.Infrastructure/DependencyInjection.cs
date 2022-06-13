using BuberDinner.Application.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
