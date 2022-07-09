using System.ComponentModel.DataAnnotations.Schema;

namespace Dateing.Models
{
   [Table("photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public int publicId { get; set; }
        public AppUser appUser { get; set; }
        public int appUserId { get; set; }

    }
}