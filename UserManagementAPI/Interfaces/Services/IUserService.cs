using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Contract.Responses.User;

namespace UserManagementAPI.Interfaces.Services;

public interface IUserService
{
    UserSearchResponse GetUser(int id);
    List<UserSearchResponse> GetAllUsers();
    UserCreateResponse CreateUser(UserCreateRequest request);
    UserUpdateResponse UpdateUser(int id, UserUpdateRequest request);
    void DeleteUser(int id);
}