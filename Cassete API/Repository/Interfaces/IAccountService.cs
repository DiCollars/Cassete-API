using System.Security.Claims;

namespace Cassete_API.Repository.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity GetIdentity(string username, string password);
    }
}
