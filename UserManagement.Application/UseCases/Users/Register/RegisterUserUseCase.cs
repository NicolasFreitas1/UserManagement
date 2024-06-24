using System.ComponentModel.DataAnnotations;
using UserManagement.Communication.Requests;
using UserManagement.Communication.Responses;
using UserManagement.Exception.ExceptionsBase;

namespace UserManagement.Application.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUserJson Execute(RequestUserJson request)
    {
        Validate(request);

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
