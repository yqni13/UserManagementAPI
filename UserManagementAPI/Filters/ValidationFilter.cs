using System.Text;
using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagementAPI.Mapping;
using UserManagementAPI.Shared.Utilities.Structs;
using UserManagementAPI.Shared.Wrappers;

namespace UserManagementAPI.Filters;

// [Copilot]: I used AI as debugging assistent to solve 
// A) the problem on making a check whenever a dto is used for query/body serialization for validations
// B) how to catch and customize errors when request dto's are set to null due to wrong types within payload
// C) how to filter a specific value from a json string by key

// Global Action Filter
// Checks on each request for a registered validation on respective dto and executes it.
public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Handle model binding errors (type-based).
        if (!context.ModelState.IsValid)
        {
            await HandleModelBindingErrors(context);
            return;
        }

        // Handle common validation errors.
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

            List<ValidationError> errors = BuildValidationErrors(result.Errors);
            var response = ExceptionMapper.ToValidationResponse(ExceptionName.INVALIDPROPERTIES, errors);

            if (!result.IsValid)
            {
                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }

        await next();
    }

    private static async Task HandleModelBindingErrors(ActionExecutingContext context)
    {
        // Read request body as json string from stream.
        string payloadString = "";
        context.HttpContext.Request.Body.Position = 0;
        using (var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
        {
            payloadString = await reader.ReadToEndAsync();
        }
        context.HttpContext.Request.Body.Position = 0;

        // Map model binding errors to List<ValidationError>.
        var bindingErrors = context.ModelState
            .Where(kvp => kvp.Value?.Errors.Count > 0)
            .SelectMany(kvp => kvp.Value!.Errors.Select(err => new ValidationError
            (
                "field",
                kvp.Key.TrimStart('$', '.') ?? "unknown",
                GetValueFromJsonString(payloadString, kvp.Key.TrimStart('$', '.')),
                "arg-invalid-modelbinding",
                "ModelBindingValidator"
            )))
            .ToList();

        var response = ExceptionMapper.ToValidationResponse(ExceptionName.INVALIDPROPERTIES, bindingErrors);
        context.Result = new BadRequestObjectResult(response);
    }

    private static string GetValueFromJsonString(string jsonString, string key)
    {
        // Filter for value that follows after key-parameter from request as json string.
        var match = Regex.Match
        (
            jsonString,
            $@"""{Regex.Escape(key)}""\s*:\s*(""(?<val>[^""]*)""|(?<val>[^,}}\s][^,}}]*))"
        );

        return match.Success ? match.Groups["val"].Value.Trim() : "unknown";
    }

    private static List<ValidationError> BuildValidationErrors(List<FluentValidation.Results.ValidationFailure> rawErrors)
    {
        List<ValidationError> errors = [];
        foreach (var err in rawErrors)
        {
            errors.Add(new ValidationError
                (
                    "field",
                    err.PropertyName,
                    err.AttemptedValue is null ? "null" : err.AttemptedValue.ToString() ?? "unknown",
                    err.ErrorMessage,
                    err.ErrorCode ?? "CustomValidator"
                )
            );
        }

        return errors;
    }
}