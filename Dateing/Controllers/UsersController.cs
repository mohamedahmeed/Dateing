using AutoMapper;
using Dateing.Interfaces;
using Dateing.Models;
using Dateing.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateing.Controllers
{
    
    public class UsersController :BaseApiController
    {
        private readonly IuserRepository user;
        private readonly IMapper mapper;

        public UsersController(IuserRepository user, IMapper mapper)
        {
            this.user = user;
            this.mapper = mapper;
        }
        [HttpGet]
       // [Authorize]
        public async Task<ActionResult<IEnumerable<MemberVm>>> GettAllUsers()
        {
            var users = await user.GetMembersAsync();
         
            return Ok(users);
        }
        [HttpGet("id")]
     
        public async Task<ActionResult<MemberVm>> GetUserById(int id)
        {
            var u = await user.GetUserByIdAsync(id);
            return mapper.Map<MemberVm>(u);
         
             
        }
        [HttpGet("name")]
        public async Task<ActionResult<MemberVm>> GetUserByName(string name)
        {
           return await user.GetMemberAsync(name);
          
           
        } 

        [HttpPost]
        
        public  ActionResult<AppUser> AddUser(AppUser a)
        {
            if (a != null)
            {
                user.saveAllAsync();
                
                
            }
            return Ok(a);
        }
    }
}
