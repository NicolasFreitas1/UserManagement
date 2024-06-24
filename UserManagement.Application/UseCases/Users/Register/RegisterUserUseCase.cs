using UserManagement.Communication.Requests;
using UserManagement.Communication.Responses;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Exception.ExceptionsBase;

namespace UserManagement.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUsersRepository _repository;

    public RegisterUserUseCase(IUsersRepository repository)
    {
        _repository = repository;
    }

    public ResponseRegisterUserJson Execute(RequestUserJson request)
    {
        Validate(request);


        var entity = new User
        {
            Address = request.Address,
            Cnpj = request.Cnpj,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            DateRegister = DateTime.UtcNow
        };

        _repository.Add(entity);

        return new ResponseRegisterUserJson();
    } 

    private void Validate(RequestUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false) 
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
