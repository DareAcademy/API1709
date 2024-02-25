using ClinicAngularAPI.Model;
using ClinicAngularAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        IPatientService patientService;

        public PatientsController(IPatientService _patientService)
        {
            patientService = _patientService;
        }

        [HttpPost]
        public void Insert(PatientDTO patientDTO)
        {
            patientService.Insert(patientDTO);
        }

        [HttpGet]
        [Route("LoadAll")]
        public List<PatientDTO> LoadAll()
        {
            return patientService.GetAll();
        }

        [HttpGet]
        [Route("Search")]
        public List<PatientDTO> Search(string Name)
        {
            return patientService.Search(Name);
        }

        [HttpPut]
        public void Update(PatientDTO patientDTO)
        {
            patientService.Update(patientDTO);
        }

        [HttpGet]
        [Route("Load")]
        public PatientDTO Load(int Id)
        {
            return patientService.Get(Id);
        }


        [HttpDelete]
        public void Delete(int Id)
        {
            patientService.Delete(Id);
        }

    }
}
