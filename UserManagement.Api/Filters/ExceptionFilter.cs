using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagement.Communication.Responses;
using UserManagement.Exception.ExceptionsBase;

namespace UserManagement.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is UserManagementException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }


    }

    private void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var ex = (ErrorOnValidationException)context.Exception;

            var errorResponse = new ResponseErrorJson(ex.Errors);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);

        }
        else if (context.Exception is UserNotFoundException)
        {

            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new ObjectResult("User not found");
        }        
        else if (context.Exception is UserAlreadyExistsException)
        {

            context.HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Result = new ObjectResult("User already exists");
        }
        else
        {
            var errorResponse = new ResponseErrorJson(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
    }    
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("unkwon error");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);

    }
}
