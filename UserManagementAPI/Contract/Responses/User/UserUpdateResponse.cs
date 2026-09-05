namespace UserManagementAPI.Contract.Responses.User;

public record UserUpdateResponse
(
    string Name,
    string? Description,
    string? Note
);