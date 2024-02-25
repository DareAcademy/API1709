using ClinicAngularAPI.Model;

namespace ClinicAngularAPI.Services
{
    public interface IPatientService
    {
        void Insert(PatientDTO patientDTO);

        List<PatientDTO> GetAll();

        List<PatientDTO> Search(string name);

        void Delete(int Id);

        PatientDTO Get(int Id);

        void Update(PatientDTO patientDTO);
    }
}
