using Microsoft.Extensions.DependencyInjection;
using UserManagement.Application.UseCases.Users.Delete;
using UserManagement.Application.UseCases.Users.GetById;
using UserManagement.Application.UseCases.Users.ListAll;
using UserManagement.Application.UseCases.Users.Register;

namespace UserManagement.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>(); 
        services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>(); 
        services.AddScoped<IListAllUsersUseCase, ListAllUsersUseCase>(); 
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>(); 
    }
}
