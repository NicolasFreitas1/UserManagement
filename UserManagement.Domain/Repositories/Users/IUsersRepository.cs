using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories.Users;
public interface IUsersRepository
{
    void Add(User user);
    Task<User> GetById(int id);
    Task<List<User>> GetAll();
    void Update(int id, User user);
    void Delete(int id);
}
