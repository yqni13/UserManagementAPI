namespace UserManagementAPI.Contract.Responses.User;

public record UserSearchResponse
(
    string Name,
    string? Description,
    string? Note
);