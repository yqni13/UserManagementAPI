namespace UserManagementAPI.Extensions;

public static class OpenApiExtension
{
    // Call for definition, documentation and convertion of OpenAPI standard.
    // Open via SwaggerUI (Browser -> http://localhost:{{port}}/swagger)
    // Open full JSON data (Browser -> http://localhost:{{port}}/swagger/v1/swagger.json)
    // (needs "launchUrl": "swagger" in launchSettings.json)
    public static IServiceCollection AddOpenApiExtension(this IServiceCollection services)
    {
        // Add service to watch for defined routes and document them.
        services.AddEndpointsApiExplorer();

        // Convert endpoints from ApiExplorer to OpenAPI standard -> useable on Swagger.
        services.AddSwaggerGen();

        return services;
    }
}