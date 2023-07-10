using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity.Models;

namespace PhoneDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IPhoneDictionaryService _phoneDictionaryService;

        public ReportController()
        {
            _phoneDictionaryService = new PhoneDictionaryService();
        }

        [HttpGet("GetPersonCountByLocationName")]
        public int GetPersonCountByLocationName(string locationName)
        {
            return _phoneDictionaryService.GetPersonCountByLocationName(locationName);
        }

        [HttpGet("GetPhoneNumberCountByLocationName")]
        public int GetPhoneNumberCountByLocationName(string locationName)
        {
            return _phoneDictionaryService.GetPhoneNumberCountByLocationName(locationName);
        }

        

    }
}
