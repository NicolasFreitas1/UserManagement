using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Exception.ExceptionsBase;
using UserManagement.Infrastructure.DataAccess;

namespace UserManagement.Domain.Repositories.Users;

internal class UsersRepository : IUsersRepository
{
    private readonly UserManagementDbContext _dbContext;
    public UsersRepository(UserManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        var userExists = _dbContext.Users.FirstOrDefault(u => u.Cnpj == user.Cnpj);

        if (userExists != null) 
        {
            throw new UserAlreadyExistsException();
        }

         _dbContext.Users.Add(user);

         _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
       var user =  _dbContext.Users.Find(id);

        if (user == null) 
        {
            throw new UserNotFoundException();
        }

        _dbContext.Users.Remove(user);
         _dbContext.SaveChanges();

    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync<User>();
    }

    public async Task<User> GetById(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            throw new UserNotFoundException();
        }

        return user;
    }

    public void Update(int id, User user)
    {
        var userFounded = _dbContext.Users.Find(id);

        if (userFounded == null)
        {
            throw new UserNotFoundException();
        }

        userFounded.Name = user.Name;
        userFounded.Address = user.Address;
        userFounded.PhoneNumber = user.PhoneNumber;
        userFounded.DateRegister = DateTime.UtcNow;

        _dbContext.Entry(userFounded).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
}
