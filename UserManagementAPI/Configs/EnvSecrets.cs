using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Configs;

public class EnvSecrets
{
    [Required(ErrorMessage = "[ASPNETCORE_ENVIRONMENT not set]")]
    public string EnvMode { get; set; } = string.Empty;

    [Required(ErrorMessage = "[AUTH_TOKEN not set]")]
    public string AuthToken { get; set; } = string.Empty;
}