using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands
{
    public class RegisterCommandHandler(IUserRepository userRepository, IJWTTokenGenerator jwtGenerator) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJWTTokenGenerator _jwtGenerator = jwtGenerator;

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            // TODO: Check if user already exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // TODO: Create user (generate unique id)
            User user = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
            _userRepository.Add(user);

            // TODO: Generate token 
            string token = _jwtGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
