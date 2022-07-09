using Dateing.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dateing.Migrations
{
    public class Seed
    {
        public static async Task setData(DatingEntity dating) 
        {
            if (await dating.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Migrations/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach (var User in users)
            {
                var hmac = new HMACSHA512();
                User.UserName = User.UserName.ToLower();
                User.passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123"));
                User.passwordSalt = hmac.Key;

              dating.Users.Add(User);
            }
          await  dating.SaveChangesAsync();
        }
    }
}
