using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            Error firstError = errors[0];
            int statusCode = firstError switch
            {
                { Type: ErrorType.Validation } => StatusCodes.Status400BadRequest,
                { Type: ErrorType.Conflict } => StatusCodes.Status409Conflict,
                { Type: ErrorType.NotFound } => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: firstError.Description);
        } 
    }
}