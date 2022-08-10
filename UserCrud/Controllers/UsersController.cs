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
    public ActionResult<UserResponse> GetUser(Guid id)
    {
        User user = _userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }

        return new UserResponse(
            user.Id,
            user.Username,
            user.FirstName,
            user.LastName,
            user.DateCreated);
    }

    [HttpGet]
    public ActionResult<List<UserResponse>> GetUsers()
    {
        User createdUser1 = UserCrud.Models.User.Create(
            "Username1",
            "FirstName1",
            "LastName1");

        User createdUser2 = UserCrud.Models.User.Create(
            "Username2",
            "FirstName2",
            "LastName2");

        User createdUser3 = UserCrud.Models.User.Create(
            "Username3",
            "FirstName3",
            "LastName3");
        
        List<UserResponse> users = new List<UserResponse>();
        users.Add(new UserResponse(
            createdUser1.Id,
            createdUser1.Username,
            createdUser1.FirstName,
            createdUser1.LastName,
            createdUser1.DateCreated));
        users.Add(new UserResponse(
            createdUser2.Id,
            createdUser2.Username,
            createdUser2.FirstName,
            createdUser2.LastName,
            createdUser2.DateCreated));
        users.Add(new UserResponse(
            createdUser3.Id,
            createdUser3.Username,
            createdUser3.FirstName,
            createdUser3.LastName,
            createdUser3.DateCreated));

        List<User> userIndex = _userService.GetAll();

        return Ok(userIndex);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<UserResponse> UpdateUser(Guid id, UpdateUserRequest request)
    {
        User user = _userService.Get(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Username = request.Username;

        user.FirstName = request.FirstName;

        user.LastName = request.LastName;

        _userService.Update(user);

        return new UserResponse(
            user.Id,
            user.Username,
            user.FirstName,
            user.LastName,
            user.DateCreated);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<UserResponse> DeleteUser(Guid id)
    {
        User user = _userService.Delete(id);
        if (user == null)
        {
            return NotFound();
        }

        return new UserResponse(
            user.Id,
            user.Username,
            user.FirstName,
            user.LastName,
            user.DateCreated);
    }
}
