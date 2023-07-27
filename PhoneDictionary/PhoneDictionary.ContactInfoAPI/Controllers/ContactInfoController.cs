using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.APIModel;
using PhoneDictionary.Entity.Models;
using System.Net;

namespace PhoneDictionary.ContactInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private IPhoneDictionaryService _phoneDictionaryService;

        public ContactInfoController()
        {
            _phoneDictionaryService = new PhoneDictionaryService();
        }
        /// <summary>
        /// idsi verilen kişinin iletişim bilgilerini siler
        /// </summary>
        /// <param name="personId"></param>
        [HttpPost("DeleteContactInfoByPersonId")]
        public Person DeleteContactInfoByPersonId([FromBody] DeletePersonRequestModel model)
        {
            var resp = _phoneDictionaryService.RemoveAllContactInfoById(model.PersonId);
            return resp;
        }
    } 
}
