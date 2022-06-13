﻿using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencies(
      this IServiceCollection services, IConfiguration configration)
    {
    services.Configure<JwtSettings>(configration.GetSection(JwtSettings.SectionName));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
      services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
      return services;
    }
}
