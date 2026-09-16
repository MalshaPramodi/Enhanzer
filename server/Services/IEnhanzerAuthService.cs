using Server.DTOs;

namespace Server.Services
{
    public interface IEnhanzerAuthService
    {
        Task<EnhanzerInvokeResponse?> LoginAsync(string email, string password);
    }
}