using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagementAPI.Shared.Wrappers;

namespace UserManagementAPI.Filters;

/// <summary>
/// Global Action Filter
/// Checks on each request for a registered validation on respective dto and executes it.
/// 
/// [I used Copilot as debugging assistent to solve the problem on making a check
/// whenever a dto is used for query/body serialization for validation.]
/// </summary>
public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var arg in context.ActionArguments.Values)
        {
            if (arg is null)
                continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
            IValidator? validator = _serviceProvider.GetService(validatorType) as IValidator;

            if (validator is null)
                continue;

            var validationContext = new ValidationContext<object>(arg);
            var result = await validator.ValidateAsync(validationContext);

            List<ValidationError> errors = new();
            foreach (var err in result.Errors)
            {
                errors.Add(
                    new ValidationError
                    (
                        "field",
                        err.AttemptedValue.ToString() ?? "unknown",
                        err.ErrorMessage,
                        err.ErrorCode
                    )
                );
            }

            var response = new ValidationResponse
            {
                Headers = new ValidationResponseHeader
                {
                    Error = "InvalidPropertiesException",
                    Status = StatusCodes.Status400BadRequest,
                    Message = "arg-invalid-properties",
                    Data = errors
                }
            };

            if (!result.IsValid)
            {
                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }

        await next();
    }
}