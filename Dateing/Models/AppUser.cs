

using Dateing.extinatino;
using System;
using System.Collections.Generic;

namespace Dateing.Models
{
    public class AppUser
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt{ get; set; }
       
        public DateTime DateOfBirth { get; set; }

        internal object calcAge()
        {
            throw new NotImplementedException();
        }

        public DateTime LastActive { get; set; }=DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public string Introduction { get; set; }

        public string Interests { get; set; }
        public string LookingFor { get; set; }
        public ICollection<Photo> Photos { get; set; }

        //public int GetAge()
        //{
        //    return DateOfBirth.calcAge();
        //}










    }
}
