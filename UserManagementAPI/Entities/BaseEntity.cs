namespace UserManagementAPI.Entities;

public abstract class BaseEntity
{
    public DateTime? LastUsed { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}