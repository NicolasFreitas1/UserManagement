using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Domain.Repositories.Users;
using UserManagement.Infrastructure.DataAccess;

namespace UserManagement.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services) 
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
    }   
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddDbContext<UserManagementDbContext>(config => config.UseNpgsql(connectionString));
    }
}
