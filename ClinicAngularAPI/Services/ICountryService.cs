using ClinicAngularAPI.Model;

namespace ClinicAngularAPI.Services
{
    public interface ICountryService
    {
        void Insert(CountryDTO country);

        List<CountryDTO> GetAll();

        void Delete(int Id);

        CountryDTO Get(int Id);

        void Update(CountryDTO countryDTO);
    }
}
