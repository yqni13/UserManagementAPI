using UserManagementAPI.Configs;

namespace UserManagementAPI.Extensions;

public static class SecretsExtension
{
    public static IServiceCollection RegisterEnvSecrets(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<EnvSecrets>()
            .Configure(options =>
            {
                options.EnvMode = configuration["ASPNETCORE_ENVIRONMENT"] ?? string.Empty;
                options.AuthToken = configuration["AUTH_TOKEN"] ?? string.Empty;
            })
            .ValidateDataAnnotations()
            .ValidateOnStart(); // Check validators in AuthSecrets to crash application if secret is null/empty.

        return services;
    }
}