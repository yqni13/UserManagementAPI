using FluentValidation;
using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Extensions;
using UserManagementAPI.Shared.Utilities.Structs;

namespace UserManagementAPI.Validations.User;

public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(BaseExceptionMsg.REQUIRED)
            .MinimumLength(5).WithMessage("arg-invalid-min#name!5")
            .MaximumLength(50).WithMessage("arg-invalid-max#name!50");

        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(10).WithMessage("arg-invalid-min#description!10")
            .MaximumLength(256).WithMessage("arg-invalid-max#description!256")
            .Optional();

        RuleFor(x => x.Note)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(10).WithMessage("arg-invalid-min#note!10")
            .MaximumLength(256).WithMessage("arg-invalid-max#note!256")
            .Optional();
    }
}