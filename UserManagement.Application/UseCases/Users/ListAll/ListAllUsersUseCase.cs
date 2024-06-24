using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.UseCases.Users.ListAll;

public class ListAllUsersUseCase : IListAllUsersUseCase
{
    private readonly IUsersRepository _repository;

    public ListAllUsersUseCase(IUsersRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> Execute ()
    {
        var users = await _repository.GetAll();

        return users;
    }
}
