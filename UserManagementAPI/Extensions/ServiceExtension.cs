using UserManagementAPI.Interfaces.Services;
using UserManagementAPI.Services;

namespace UserManagementAPI.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}