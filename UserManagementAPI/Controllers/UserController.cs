using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Contract.Requests.User;
using UserManagementAPI.Contract.Responses.User;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(typeof(List<UserSearchResponse>), (int)HttpStatusCode.OK)]
    public IActionResult GetAll()
    {
        // return List<User>
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserSearchResponse), (int)HttpStatusCode.OK)]
    public IActionResult GetById([FromRoute] UserByIdQuery query)
    {
        // return User
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserCreateResponse), (int)HttpStatusCode.OK)]
    public IActionResult Create([FromBody] UserCreateRequest request)
    {
        // return User (response)
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UserUpdateResponse), (int)HttpStatusCode.OK)]
    public IActionResult Update([FromRoute] UserByIdQuery query, [FromBody] UserUpdateRequest request)
    {
        // return string to confirm update
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public IActionResult Delete([FromRoute] UserByIdQuery query)
    {
        // return bool
    }
}