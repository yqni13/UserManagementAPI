using FluentValidation;
using UserManagementAPI.Contract.Requests.User;

namespace UserManagementAPI.Validations.User;

public class UserByIdValidator : AbstractValidator<UserByIdQuery>
{
    public UserByIdValidator()
    {
        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .Must(id => int.TryParse(id, out _)).WithMessage("arg-invalid-type#id!int")
            .Must(id => int.TryParse(id, out var val) && val >= 0).WithMessage("arg-invalid-min#id!0");
    }
}