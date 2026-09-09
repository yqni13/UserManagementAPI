using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Attributes;
using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Contract.Responses.User;
using UserManagementAPI.Interfaces.Services;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<UserSearchResponse>), (int)HttpStatusCode.OK)]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserSearchResponse), (int)HttpStatusCode.OK)]
    public IActionResult GetById([FromRoute] UserByIdQuery query)
    {
        int id = int.Parse(query.Id);
        return Ok(_userService.GetUser(id));
    }

    [HttpPost]
    [RequestValidation]
    [ProducesResponseType(typeof(UserCreateResponse), (int)HttpStatusCode.Created)]
    public IActionResult Create([FromBody] UserCreateRequest request)
    {
        return CreatedAtAction(nameof(Create), _userService.CreateUser(request));
    }

    [HttpPut("{id}")]
    [RequestValidation]
    [ProducesResponseType(typeof(UserUpdateResponse), (int)HttpStatusCode.OK)]
    public IActionResult Update([FromRoute] UserByIdQuery query, [FromBody] UserUpdateRequest request)
    {
        int id = int.Parse(query.Id);
        return Ok(_userService.UpdateUser(id, request));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public IActionResult Delete([FromRoute] UserByIdQuery query)
    {
        int id = int.Parse(query.Id);
        _userService.DeleteUser(id);

        return NoContent();
    }
}