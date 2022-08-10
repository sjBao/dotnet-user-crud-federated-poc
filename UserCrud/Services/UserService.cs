using UserCrud.Models;

namespace UserCrud.Services.Users;

public class UserService : IUserService
{
    // store users in-memory for now
    private readonly static Dictionary<Guid, User> _users = new();

    public User Create(User user)
    {
        _users.Add(user.Id, user);
        return user;
    }

    public User Update(User user)
    {
        _users[user.Id] = user;
        return user;
    }

    public User Get(Guid id)
    {
        return _users[id];
    }

    public User Delete(Guid id)
    {
        var user = _users[id];
        _users.Remove(id);
        return user;
    }

    public List<User> GetAll()
    {
        return _users.Values.ToList();
    }
}
