using UserCrud.Models;

namespace UserCrud.Services.Users;

public interface IUserService
{
    User Create(User request);
    User Update(User request);
    User Get(Guid id);
    User Delete(Guid id);
    List<User> GetAll();
}
