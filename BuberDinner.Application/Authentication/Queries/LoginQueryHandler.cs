using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries
{
    public class LoginQueryHandler(IUserRepository userRepository, IJWTTokenGenerator jwtGenerator) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJWTTokenGenerator _jwtGenerator = jwtGenerator;

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // TODO: Validate user
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // TODO: Validate password
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // TODO: Generate token
            string token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
