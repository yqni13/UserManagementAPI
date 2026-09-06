using UserManagementAPI.Contract.Responses.User;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Mapping;

// Classic client response should not necessarily contain data like creation timestamp, id and so forth -
// but for the matter of this learning project we just ignore that for now.
public static class UserMapper
{
    public static UserSearchResponse ToSearchResponse(User user)
    {
        return new UserSearchResponse
        (
            UserId: user.UserId,
            Name: user.Name,
            Description: user.Description,
            Note: user.Note,
            UpdatedAt: user.UpdatedAt,
            CreatedAt: user.CreatedAt
        );
    }

    public static UserCreateResponse ToCreateResponse(User user)
    {
        return new UserCreateResponse
        (
            UserId: user.UserId,
            Name: user.Name,
            Description: user.Description,
            Note: user.Note,
            UpdatedAt: user.UpdatedAt,
            CreatedAt: user.CreatedAt
        );
    }

    public static UserUpdateResponse ToUpdateResponse(User user)
    {
        return new UserUpdateResponse
        (
            UserId: user.UserId,
            Name: user.Name,
            Description: user.Description,
            Note: user.Note,
            UpdatedAt: user.UpdatedAt,
            CreatedAt: user.CreatedAt
        );
    }
}