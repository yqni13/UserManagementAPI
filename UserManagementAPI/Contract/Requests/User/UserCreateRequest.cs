namespace UserManagementAPI.Contract.Requests.User;

public record UserCreateRequest
(
    string Name,
    string Description,
    string Note
);