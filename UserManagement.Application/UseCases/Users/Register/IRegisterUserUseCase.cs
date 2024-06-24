using UserManagement.Communication.Requests;
using UserManagement.Communication.Responses;

namespace UserManagement.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    ResponseRegisterUserJson Execute(RequestUserJson request);
}
