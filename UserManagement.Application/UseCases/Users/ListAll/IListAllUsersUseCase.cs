using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.UseCases.Users.ListAll;
public interface IListAllUsersUseCase
{
    Task<List<User>> Execute();
}
