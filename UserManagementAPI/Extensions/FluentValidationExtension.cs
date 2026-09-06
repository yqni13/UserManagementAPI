using FluentValidation;

namespace UserManagementAPI.Extensions;

public static class FluentValidationExtension
{
    // Use to replace ".Unless(x => string.IsNullOrEmpty(x.Property))" call with ".Optional()" at the end of ruleset.
    public static IRuleBuilderOptions<T, string> Optional<T>(this IRuleBuilderOptions<T, string> rule)
    {
        return rule.Unless((instance, context) =>
        {
            var value = instance
                ?.GetType()
                ?.GetProperty(context.PropertyPath)
                ?.GetValue(instance)
                ?.ToString();

            return string.IsNullOrEmpty(value);
        });
    }
}