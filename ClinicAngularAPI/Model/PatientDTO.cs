using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ClinicAngularAPI.data;

namespace ClinicAngularAPI.Model
{
    [AutoMap(typeof(Patient),ReverseMap =true)]
    public class PatientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please fill First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fill Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please fill DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please fill Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please fill Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select Country")]
        public int Country_Id { get; set; }

        public CountryDTO? country { get; set; }
    }
}
