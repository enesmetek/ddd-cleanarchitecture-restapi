using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService(IJWTTokenGenerator jwtGenerator, IUserRepository userRepository) : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtGenerator = jwtGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // TODO: Check if user already exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists!");
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

        public AuthenticationResult Login(string email, string password)
        {
            // TODO: Validate user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist!");
            }

            // TODO: Validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid password!");
            }

            // TODO: Generate token
            string token = _jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
