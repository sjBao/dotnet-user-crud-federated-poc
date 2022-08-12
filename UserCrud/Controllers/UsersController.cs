using UserCrud.Contracts.User;
using UserCrud.Models;
using UserCrud.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace UserCrud.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult<UserResponse> CreateUser(CreateUserRequest request)
    {
        User createdUser = UserCrud.Models.User.Create(
            request.Username,
            request.FirstName,
            request.LastName);

        _userService.Create(createdUser);

        return new UserResponse(
            createdUser.Id,
            createdUser.Username,
            createdUser.FirstName,
            createdUser.LastName,
            createdUser.DateCreated);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserResponse>> GetUser(Guid id)
    {
        try
        {
            User user = await _userService.Get(id);
            return Ok(user);
        }
        catch (System.Exception)
        {
            return NotFound("User not found");
        }

    }

    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {

        List<User> userIndex = await _userService.GetAll();

        return Ok(userIndex);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UserResponse>> UpdateUser(Guid id, UpdateUserRequest request)
    {
        try
        {
            User updatedUser = await _userService.Update(id, request);

            return Ok(updatedUser);
        }
        catch (System.Exception)
        {
            return NotFound("User could not be found");
        }
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<UserResponse> DeleteUser(Guid id)
    {
        try
        {
            User user = _userService.Delete(id);
            return Ok(user);

        }
        catch (System.Exception)
        {
            return NotFound("User could not be found");
        }
    }
}
