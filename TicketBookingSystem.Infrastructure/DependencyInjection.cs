using Microsoft.Extensions.DependencyInjection;
using TicketBookingSystem.Application.Interfaces.Repositories;
using TicketBookingSystem.Application.Interfaces.Services;
using TicketBookingSystem.Application.Services;
using TicketBookingSystem.Infrastructure.Repositories;

namespace TicketBookingSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}