using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.Users.Delete;
using UserManagement.Application.UseCases.Users.GetById;
using UserManagement.Application.UseCases.Users.ListAll;
using UserManagement.Application.UseCases.Users.Register;
using UserManagement.Communication.Requests;
using UserManagement.Communication.Responses;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public IActionResult Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestUserJson request) 
    {
        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromServices] IGetUserByIdUseCase useCase, [FromRoute] int id) 
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }    

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromServices] IListAllUsersUseCase useCase) 
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Route("{id}")]
    public IActionResult Delete([FromServices] IDeleteUserUseCase useCase, [FromRoute] int id) 
    {
        useCase.Execute(id);

        return NoContent();
    }
}
