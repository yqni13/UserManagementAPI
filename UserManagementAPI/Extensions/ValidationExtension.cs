using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Filters;

namespace UserManagementAPI.Extensions;

public static class ValidationExtension
{
    public static IServiceCollection RegisterValidators(this IServiceCollection services)
    {
        // Surpressing ModelState check for type checks of query params.
        services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

        // Registration of all validation files with Program.cs as marker.
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.Configure<MvcOptions>(options => { options.Filters.Add<ValidationFilter>(); });

        return services;
    }
}