using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.UseCases.Users.GetById;

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUsersRepository _repository;

    public GetUserByIdUseCase(IUsersRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Execute(int Id)
    {
        var user = _repository.GetById(Id);

        return user;
    }
}
