using System.ComponentModel.DataAnnotations;

namespace ClinicAngularAPI.Models
{
    public class SignIn
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool rememberMe { get; set; }
    }
}
