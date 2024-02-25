using System.ComponentModel.DataAnnotations;

namespace ClinicAngularAPI.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}
