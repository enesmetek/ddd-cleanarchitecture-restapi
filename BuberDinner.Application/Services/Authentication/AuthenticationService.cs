using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService(IJWTTokenGenerator jwtGenerator) : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jwtGenerator = jwtGenerator;

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // TODO: Check if user already exists

            // TODO: Create user (generate unique id)

            // TODO: Generate token 
            Guid userId = Guid.NewGuid();
            string token = _jwtGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
        }
    }
}
