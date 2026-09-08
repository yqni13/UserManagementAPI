namespace UserManagementAPI.Shared.Wrappers;

public record ValidationResponseHeader
{
    public string Error { get; init; } = string.Empty;
    public int Status { get; init; }
    public string Message { get; init; } = string.Empty;
    public List<ValidationError> Data { get; init; } = new();
}