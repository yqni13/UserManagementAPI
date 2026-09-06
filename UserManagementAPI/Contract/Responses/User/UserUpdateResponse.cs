namespace UserManagementAPI.Contract.Responses.User;

public record UserUpdateResponse
(
    int UserId,
    string Name,
    string? Description,
    string? Note,
    DateTime UpdatedAt,
    DateTime CreatedAt
);