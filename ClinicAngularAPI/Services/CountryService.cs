using AutoMapper;
using ClinicAngularAPI.data;
using ClinicAngularAPI.Model;

namespace ClinicAngularAPI.Services
{
    public class CountryService:ICountryService
    {
        ClinicContext context;
        IMapper mapper;
        public CountryService(ClinicContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }


        public void Insert(CountryDTO country)
        {
            Country newCountry = mapper.Map<Country>(country);

            context.Countries.Add(newCountry);
            context.SaveChanges();

        }

        public List<CountryDTO> GetAll()
        {
            List<Country> allCountries = context.Countries.ToList();

            List<CountryDTO> countries = mapper.Map<List<CountryDTO>>(allCountries);

            return countries;
        }

        public void Delete(int Id)
        {
            Country country = context.Countries.Find(Id);
            context.Countries.Remove(country);
            context.SaveChanges();
        }

        public CountryDTO Get(int Id)
        {
            Country country = context.Countries.Find(Id);
            CountryDTO countryDTO = mapper.Map<CountryDTO>(country);
            return countryDTO;
        }

        public void Update(CountryDTO countryDTO)
        {
            Country country = mapper.Map<Country>(countryDTO);

            context.Countries.Attach(country);
            context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
