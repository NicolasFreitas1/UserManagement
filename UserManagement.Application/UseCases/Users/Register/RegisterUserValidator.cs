using FluentValidation;
using UserManagement.Communication.Requests;

namespace UserManagement.Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("The name is required");
        RuleFor(user => user.Address).NotEmpty().WithMessage("The address is required");
        RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage("The phone is required");
        RuleFor(user => user.Cnpj).NotEmpty().WithMessage("The Cnpj is required");
    }
}
