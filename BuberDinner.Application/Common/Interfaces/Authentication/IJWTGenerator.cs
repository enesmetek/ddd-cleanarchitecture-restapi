using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user);
    }
}
