using System.ComponentModel.DataAnnotations;

namespace Dateing.VM
{
    public class RegisterVm
    {
       
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
