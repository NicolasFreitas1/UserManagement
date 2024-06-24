using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Communication.Requests;

namespace UserManagement.Application.UseCases.Users.Edit;
public interface IEditUserUseCase
{
    void Execute(int id, RequestEditUserJson request);
}
