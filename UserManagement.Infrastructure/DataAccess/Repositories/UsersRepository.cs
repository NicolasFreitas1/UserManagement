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

    public async void Add(User user)
    {
        var userExists = await _dbContext.Users.FirstOrDefaultAsync(u => u.Cnpj == user.Cnpj);

        if (userExists != null) 
        {
            throw new UserAlreadyExistsException();
        }

        _dbContext.Users.Add(user);

        _dbContext.SaveChanges();
    }

    public async void Delete(int id)
    {
       var user = await _dbContext.Users.FindAsync(id);

        if (user == null) 
        {
            throw new UserNotFoundException();
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

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

    public async void Update(int id, User user)
    {
        var userFounded = await _dbContext.Users.FindAsync(id);

        if (userFounded == null)
        {
            throw new UserNotFoundException();
        }

        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
