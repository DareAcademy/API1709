using AutoMapper;
using ClinicAngularAPI.data;
using System.ComponentModel.DataAnnotations;

namespace ClinicAngularAPI.Model
{
    [AutoMap(typeof(Country), ReverseMap = true)]
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill Country Code")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Please fill Country Name")]
        public string Name { get; set; }
    }
}
