using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Contract.Responses.User;
using UserManagementAPI.Entities;
using UserManagementAPI.Interfaces.Services;
using UserManagementAPI.Mapping;
using UserManagementAPI.Shared.Utilities.Exceptions;

namespace UserManagementAPI.Services;

public class UserService : IUserService
{

    public UserSearchResponse GetUser(int id)
    {
        User? user = InternDB.USERS.FirstOrDefault(user => user.UserId == id);
        if (user is null)
            throw new NotFoundException($"User with ID ({id}) not found.");

        return UserMapper.ToSearchResponse(user);
    }

    public List<UserSearchResponse> GetAllUsers()
    {
        List<UserSearchResponse> users = new();
        foreach (User user in InternDB.USERS)
        {
            users.Add(UserMapper.ToSearchResponse(user));
        }

        return users;
    }

    public UserCreateResponse CreateUser(UserCreateRequest request)
    {
        DateTime timestamp = DateTime.Now;
        User user = new User
        {
            UserId = InternDB.USER_CURR_ID,
            Name = request.Name,
            Description = request.Description,
            Note = request.Note,
            UpdatedAt = timestamp,
            CreatedAt = timestamp
        };
        InternDB.USER_CURR_ID++;
        InternDB.USERS.Add(user);

        return UserMapper.ToCreateResponse(user);
    }

    // [Copilot]: I used AI to refactor my code and got the explanation for how referenced types work.

    // FirstOrDefault returns REFERENCE of object in heap => user.Name = request.Name modifies referenced obj value.
    public UserUpdateResponse UpdateUser(int id, UserUpdateRequest request)
    {
        User? user = InternDB.USERS.FirstOrDefault(user => user.UserId == id);
        if (user is null)
            throw new NotFoundException($"User with ID ({id}) not found.");

        DateTime timestamp = DateTime.Now;

        user.Name = request.Name;
        user.Description = request.Description;
        user.Note = request.Note;
        user.UpdatedAt = timestamp;

        return UserMapper.ToUpdateResponse(user);
    }

    public bool DeleteUser(int id)
    {
        int index = InternDB.USERS.FindIndex(user => user.UserId == id);
        if (index < 0)
            throw new NotFoundException($"User with ID ({id}) not found.");

        InternDB.USERS.RemoveAt(index);
        return true;
    }
}