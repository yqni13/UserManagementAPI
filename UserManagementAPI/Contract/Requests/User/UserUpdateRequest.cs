namespace UserManagementAPI.Contract.Requests.User;

public record UserUpdateRequest
(
    string Name,
    string Description,
    string Note
);