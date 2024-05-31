using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController(ISender mediator) : ApiController
    {

        private readonly ISender _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = new(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = new(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        }
    }
}
