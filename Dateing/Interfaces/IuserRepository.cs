using Dateing.Models;
using Dateing.VM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dateing.Interfaces
{
    public interface IuserRepository
    {
         void Ubdate(AppUser user);
        Task<bool> saveAllAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByNameAsync(string Name);

        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<IEnumerable<MemberVm>> GetMembersAsync();
        Task<MemberVm> GetMemberAsync( string name);



    }
}
