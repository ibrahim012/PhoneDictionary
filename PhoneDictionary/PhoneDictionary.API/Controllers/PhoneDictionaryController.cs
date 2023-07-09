using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity;

namespace PhoneDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneDictionaryController : ControllerBase
    {
        private IPhoneDictionaryService _phoneDictionaryService;

        public PhoneDictionaryController()
        {
            _phoneDictionaryService = new PhoneDictionaryService();
        }

        [HttpGet("GetAllPerson")]
        public List<Person> GetAllPerson()
        {
            var response = _phoneDictionaryService.GetAllPerson();
            return response;
        }
    }
}
