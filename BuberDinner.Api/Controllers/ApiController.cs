using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
                return Problem();

            if (errors.All(error => error.Type == ErrorType.Validation))
                return ValidationProblem(errors);

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;
            return Problem(errors[0]);
        }

        private IActionResult Problem(Error error)
        {
            int statusCode = error switch
            {
                { Type: ErrorType.Validation } => StatusCodes.Status400BadRequest,
                { Type: ErrorType.Conflict } => StatusCodes.Status409Conflict,
                { Type: ErrorType.NotFound } => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            ModelStateDictionary modelStateDictionary = new();
            errors.ForEach(error => modelStateDictionary.AddModelError(error.Code, error.Description));
            return ValidationProblem(modelStateDictionary);
        }
    }
}