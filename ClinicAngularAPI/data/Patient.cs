using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAngularAPI.data
{
    public class Patient
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        
        [StringLength(10)]
        public string Gender { get; set; }

        [ForeignKey("country")]
        public int Country_Id { get; set; }

        public Country country { get; set; }

    }
}
