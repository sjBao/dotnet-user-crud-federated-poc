using UserCrud.Models;
using UserCrud.Contracts.User;
namespace UserCrud.Services.Users;

public interface IUserService
{
    User Create(User request);
    Task<User> Update(Guid id, UpdateUserRequest request);
    Task<User> Get(Guid id);
    User Delete(Guid id);
    Task<List<User>> GetAll();
}
