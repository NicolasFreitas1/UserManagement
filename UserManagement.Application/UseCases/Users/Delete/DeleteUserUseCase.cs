using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.UseCases.Users.Delete;

public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUsersRepository _repository;

    public DeleteUserUseCase(IUsersRepository repository)
    {
        _repository = repository;
    }

    public void Execute(int id)
    {
        _repository.Delete(id);
    }
}
