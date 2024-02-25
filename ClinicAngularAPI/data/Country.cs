using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicAngularAPI.data
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
