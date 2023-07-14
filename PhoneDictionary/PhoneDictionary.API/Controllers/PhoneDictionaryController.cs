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
          
        /// <summary>
        /// tüm kişileri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPerson")]
        public List<PersonDetailModel> GetAllPerson()
        {
            var response = _phoneDictionaryService.GetAllPerson();
            return response;
        }

        /// <summary>
        /// Idsi verilen kişiye listeler
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet("GetPersonById")]
        public List<PersonDetailModel> GetPersonById(int personId)
        {
            return _phoneDictionaryService.GetPersonById(personId);
        }

        /// <summary>
        /// yeni kişi oluşturur
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("CreatePerson")]
        public PersonModel Create(PersonModel person)
        {
            _phoneDictionaryService.CreatePerson(person);
            return person;
        }

        /// <summary>
        /// idsi verilen kişiyi günceller
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("UpdatePerson")]
        public Person Update(PersonModel person)
        {
            return _phoneDictionaryService.UpdatePerson(person);
        }

        /// <summary>
        /// idsi verilen kişiyi siler
        /// </summary>
        /// <param name="personId"></param>
        [HttpPost("DeletePerson")]
        public void Delete(int personId)
        {
            _phoneDictionaryService.DeletePerson(personId);
        }

        /// <summary>
        /// kişiye yeni iletişim bilgisi ekler
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("AddContactInfo")]
        public Person AddContactInfo(ContactInfoModel contactInfo, int userId)
        {
            return _phoneDictionaryService.AddContactInfo(contactInfo, userId);
        }
        //idsi verilen kişiden iletişim tipi verilen iletişim bilgisini kaldırır

        [HttpPost("RemoveContactInfoById")]
        public Person RemoveContactInfoById(int personId,ContactInfo.InfoTypes infoTypeId)
        {
            return _phoneDictionaryService.RemoveContactInfoById(personId, infoTypeId);
        }
      }
}
