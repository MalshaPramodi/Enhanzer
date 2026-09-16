namespace Server.Services
{
    public interface IJwtService
    {
        string GenerateToken(string email);
    }
}