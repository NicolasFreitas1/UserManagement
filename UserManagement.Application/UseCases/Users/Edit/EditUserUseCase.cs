using UserManagement.Communication.Requests;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories.Users;

namespace UserManagement.Application.UseCases.Users.Edit;

public class EditUserUseCase : IEditUserUseCase
{
    private readonly IUsersRepository _repository;

    public EditUserUseCase(IUsersRepository repository)
    {
        _repository = repository;
    }

    public void Execute(int id, RequestEditUserJson request)
    {
        var user = new User()
        {
            Name = request.Name,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber
        };

        _repository.Update(id, user);

    }

}
