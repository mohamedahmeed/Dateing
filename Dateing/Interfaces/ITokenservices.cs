using Dateing.Models;

namespace Dateing.Interfaces
{
    public interface ITokenservices
    {
        string GetToken(AppUser user);
    }
}
