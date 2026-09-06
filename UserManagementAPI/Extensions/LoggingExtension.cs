using Serilog;

namespace UserManagementAPI.Extensions;

public static class LoggingExtension
{
    public static IHostBuilder AddSerilogLogging(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, config) =>
        {
            config
                .WriteTo.Console()
                .WriteTo.File(
                    path: "Infrastructure/Logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                );
        });

        return hostBuilder;
    }
}