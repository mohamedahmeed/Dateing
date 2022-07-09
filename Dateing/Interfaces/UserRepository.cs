using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dateing.Models;
using Dateing.VM;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateing.Interfaces
{
    public class UserRepository : IuserRepository
    {
        private readonly DatingEntity dating;
        private readonly IMapper mapper;

        public UserRepository(DatingEntity dating,IMapper mapper)
        {
            this.dating = dating;
            this.mapper = mapper;
        }

        public Task<MemberVm> GetMemberAsync(string name)
        {
            return dating.Users
                .Where(s => s.UserName == name)
                 .ProjectTo<MemberVm>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();   
        }

        public async Task<IEnumerable<MemberVm>> GetMembersAsync()
        {
            return await dating.Users.
                ProjectTo<MemberVm>(mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
           
            return await dating.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByNameAsync(string Name)
        {
            return await dating.Users.Include(s=>s.Photos).Where(s => s.UserName == Name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await dating.Users.Include(s => s.Photos).ToListAsync();
        }

        public async Task<bool> saveAllAsync()
        {
            return await dating.SaveChangesAsync() > 0;
        }

        public void Ubdate(AppUser user)
        {
           dating.Entry(user).State = EntityState.Modified;
        }
    }
}
