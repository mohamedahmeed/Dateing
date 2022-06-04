using Microsoft.EntityFrameworkCore;

namespace Dateing.Models
{
    public class DatingEntity:DbContext
    {
        public DatingEntity()
        {
                
        }

        public DatingEntity( DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}
