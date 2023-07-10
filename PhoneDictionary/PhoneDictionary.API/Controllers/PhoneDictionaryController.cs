using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Models;

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
        public List<PersonDetailModel> GetAllPerson()
        {
            var response = _phoneDictionaryService.GetAllPerson();
            return response;
        }

        [HttpGet("GetPersonById")]
        public List<PersonDetailModel> GetPersonById(int personId)
        {
            return _phoneDictionaryService.GetPersonById(personId);
        }

        [HttpPost("CreatePerson")]
        public PersonModel Create(PersonModel person)
        {
            _phoneDictionaryService.CreatePerson(person);
            return person;
        }

        [HttpPost("UpdatePerson")]
        public Person Update(PersonModel person)
        {
            return _phoneDictionaryService.UpdatePerson(person);
        }

        [HttpPost("DeletePerson")]
        public void Delete(int personId)
        {
            _phoneDictionaryService.DeletePerson(personId);
        }

        [HttpPost("AddContactInfo")]
        public Person AddContactInfo(ContactInfoModel contactInfo, int userId)
        {
            return _phoneDictionaryService.AddContactInfo(contactInfo, userId);
        }

        [HttpPost("RemoveContactInfoById")]
        public Person RemoveContactInfoById(int personId,ContactInfo.InfoTypes infoTypeId)
        {
            return _phoneDictionaryService.RemoveContactInfoById(personId, infoTypeId);
        }
      }
}
