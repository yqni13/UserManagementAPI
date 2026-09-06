namespace UserManagementAPI.Shared.Wrappers;

public record ValidationResponse
{
    public ValidationResponseHeader Headers { get; init; } = new();
}