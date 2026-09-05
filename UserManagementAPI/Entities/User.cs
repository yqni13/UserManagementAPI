namespace UserManagementAPI.Entities;

public class User : BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Note { get; set; }

    // public Address? Address { get; set; }
    // public Contact? Contact { get; set; }
}