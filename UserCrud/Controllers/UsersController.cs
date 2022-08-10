namespace UserCrud.Controllers;

using UserCrud.Contracts.User;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public ActionResult<UserResponse> CreateUser(CreateUserRequest request)
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public ActionResult<UserResponse> GetUser(Guid id)
    {
        return Ok();
    }

    [HttpGet]
    public ActionResult<UserResponse> GetUsers()
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<UserResponse> UpdateUser(Guid id, UpdateUserRequest request)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<UserResponse> DeleteUser(Guid id)
    {
        return Ok();
    }
}
