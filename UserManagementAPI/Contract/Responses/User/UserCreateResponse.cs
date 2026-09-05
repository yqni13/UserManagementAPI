namespace UserManagementAPI.Contract.Responses.User;

public record UserCreateResponse
(
    string Name,
    string? Description,
    string? Note
);