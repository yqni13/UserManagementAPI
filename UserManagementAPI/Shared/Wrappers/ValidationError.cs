namespace UserManagementAPI.Shared.Wrappers;

public record ValidationError(string Type, string Location, string Value, string Msg, string Validator);