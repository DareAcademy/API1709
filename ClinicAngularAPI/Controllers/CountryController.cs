using ClinicAngularAPI.Model;
using ClinicAngularAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        ICountryService CountryService;
        public CountryController(ICountryService _CountryService)
        {
            CountryService = _CountryService;
        }

        [HttpPost]
        public void Insert(CountryDTO country)
        {
            CountryService.Insert(country);
        }

        [HttpGet]
        [Route("LoadAll")]
        public List<CountryDTO> LoadAll()
        {
           return CountryService.GetAll();
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            CountryService.Delete(Id);
        }

        [HttpGet]
        [Route("Load")]
        public CountryDTO Load(int Id)
        {
            return CountryService.Get(Id);
        }

        [HttpPut]
        public void Update(CountryDTO countryDTO)
        {
            CountryService.Update(countryDTO);
        }
    }
}
