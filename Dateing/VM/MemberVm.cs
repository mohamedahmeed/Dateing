using Dateing.Models;
using System;
using System.Collections.Generic;

namespace Dateing.VM
{
    public class MemberVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public DateTime LastActive { get; set; } 
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
        public string Introduction { get; set; }

        public string Interests { get; set; }
        public string LookingFor { get; set; }
        public ICollection<PhotoVm> Photos { get; set; }

    }
}
