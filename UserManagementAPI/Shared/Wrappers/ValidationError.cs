namespace UserManagementAPI.Shared.Wrappers;

public record ValidationError(string Type, string Value, string Msg, string Validator);