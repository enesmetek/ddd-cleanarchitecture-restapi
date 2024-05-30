namespace BuberDinner.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {   
        string GenerateToken(Guid id, string firstName, string lastName); 
    }
}
