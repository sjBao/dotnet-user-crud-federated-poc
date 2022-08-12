using UserCrud.Models;
using UserCrud.Contracts.User;

namespace UserCrud.Services.Users;

public class UserService : IUserService
{
    // store users in-memory for now
    private readonly static Dictionary<Guid, User> _users = new();

    private readonly UserContext _userContext;

    public UserService(UserContext context)
    {
        _userContext = context;
    }

    public User Create(User user)
    {
        _userContext.Users.Add(user);
        _userContext.SaveChanges();
        return user;
    }

    public async Task<User> Update(Guid id, UpdateUserRequest request)
    {
        User user = await _userContext.Users.FindAsync(id);
        if (user == null)
        {
            throw new System.Exception("User could not be found");
        }
        user.Username = request.Username;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        _userContext.SaveChanges();
        
        return user;
    }

    public async Task<User> Get(Guid id)
    {
        User? user = await _userContext.Users.FindAsync(id);
        return user;
    }

    public User Delete(Guid id)
    {
        User? user = _userContext.Users.Find(id);
        if (user == null)
        {
            throw new System.Exception("User could not be found");
        }
        else
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
            return user;
        }
    }

    public async Task<List<User>> GetAll()
    {
        List<User> users = await _userContext.Users.ToListAsync();
        return users;
    }
}
