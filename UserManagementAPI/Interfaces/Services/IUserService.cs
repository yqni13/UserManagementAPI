using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Contract.Responses.User;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Interfaces.Services;

public interface IUserService
{
    UserSearchResponse GetUser(int id);
    List<UserSearchResponse> GetAllUsers();
    UserCreateResponse CreateUser(UserCreateRequest request);
    UserUpdateResponse UpdateUser(int id, UserUpdateRequest request);
    bool DeleteUser(int id);
}