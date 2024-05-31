using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService(IJWTTokenGenerator jwtGenerator, IUserRepository userRepository) : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtGenerator = jwtGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // TODO: Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;  
            }

            // TODO: Create user (generate unique id)
            User user = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // TODO: Generate token 
            string token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // TODO: Validate user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // TODO: Validate password
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // TODO: Generate token
            string token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
