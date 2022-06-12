using Dateing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dateing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatingEntity entity;

        public UsersController(DatingEntity entity)
        {
            this.entity = entity;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GettAllUsers()
        {
         return await entity.Users.ToListAsync();
        }
        [HttpGet]
        [Route("/api/{Controler}/{id}")] 
        public async Task<ActionResult<AppUser>> GetUserById(int id)
        {
           // return await entity.Users.FindAsync(id);
          // AppUser user=entity.Users.FirstOrDefault(s=>s.Id==id);
          return await entity.Users.FirstOrDefaultAsync(s=>s.Id==id);
        }
        [HttpPost]
        public  ActionResult<AppUser> AddUser(AppUser a)
        {
            if (a != null)
            {
                entity.Add(a);
                entity.SaveChanges();
                
            }
            return Ok(a);
        }
    }
}
