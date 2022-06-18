using Dateing.Interfaces;
using Dateing.Models;
using Dateing.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace Dateing.Controllers
{
   
    public class AccountController : BaseApiController
    {
        private readonly DatingEntity entity;
        private readonly ITokenservices tokenservices;

        public AccountController(DatingEntity entity, ITokenservices tokenservices)
        {
            this.entity = entity;
            this.tokenservices = tokenservices;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserVm>> register(RegisterVm register)
        {
            if (await exist(register.UserName))
            {
                return BadRequest("Name Alarady Exists");
            }
            using var x = new System.Security.Cryptography.HMACSHA512();
            var user = new AppUser()
            {
                userName = register.UserName.ToLower(),
                passwordHash = x.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                passwordSalt=x.Key,
            };
            entity.Users.Add(user);
           await entity.SaveChangesAsync();
            return new UserVm {
                UserName = user.userName,
                Token= tokenservices.GetToken(user)
            };
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserVm>> login(LoginVm login)
        {
           var user =await entity.Users.SingleOrDefaultAsync(s=>s.userName==login.UserName);
            if (user == null)
                return Unauthorized("invalid UserName");
         using   var x=new System.Security.Cryptography.HMACSHA512(user.passwordSalt);
            var computedHash=x.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordHash[i])
                    return Unauthorized("Invalid Password");
            }
            return new UserVm
            {
                UserName = user.userName,
                Token = tokenservices.GetToken(user)
            };
        }
        private async Task<bool> exist(string userName)
        {
            return await entity.Users.AnyAsync(s => s.userName == userName.ToLower());
        }
    }
}
