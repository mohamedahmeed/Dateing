using System.ComponentModel.DataAnnotations;
namespace Dateing.VM
{
    public class LoginVm
    {
   
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }

    }
}
