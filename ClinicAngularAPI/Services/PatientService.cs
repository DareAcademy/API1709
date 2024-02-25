using AutoMapper;
using ClinicAngularAPI.data;
using ClinicAngularAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClinicAngularAPI.Services
{
    public class PatientService:IPatientService
    {
        ClinicContext context;
        IMapper mapper;
        public PatientService(ClinicContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Insert(PatientDTO patientDTO)
        {
            Patient newPatient = mapper.Map<Patient>(patientDTO);

            context.Patients.Add(newPatient);
            context.SaveChanges();

        }

        public List<PatientDTO> GetAll()
        {
            List<Patient> allPatients = context.Patients.Include("country").ToList();

            List<PatientDTO> Patients = mapper.Map<List<PatientDTO>>(allPatients);

            return Patients;
        }

        public List<PatientDTO> Search(string name)
        {
            List<Patient> allPatients = context.Patients.Include("country").Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name)).ToList();

            List<PatientDTO> patients = mapper.Map<List<PatientDTO>>(allPatients);

            return patients;


        }

        public void Delete(int Id)
        {
            Patient patient = context.Patients.Find(Id);
            context.Patients.Remove(patient);
            context.SaveChanges();
        }

        public PatientDTO Get(int Id)
        {
            Patient patient = context.Patients.Find(Id);
            PatientDTO patientDTO = mapper.Map<PatientDTO>(patient);
            return patientDTO;
        }

        public void Update(PatientDTO patientDTO)
        {
            Patient patient = mapper.Map<Patient>(patientDTO);

            context.Patients.Attach(patient);
            context.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }



    }
}
