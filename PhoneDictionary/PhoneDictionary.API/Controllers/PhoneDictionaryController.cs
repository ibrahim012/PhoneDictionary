using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.APIModel;
using PhoneDictionary.Entity.Models;
using RabbitMQ.Client;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

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
        public async Task<string> Delete(int personId)
        {
            var baseUrl = "https://localhost:7288/";
            var urlWithMethod = "api/ContactInfo/DeleteContactInfoByPersonId";

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var person = new DeletePersonRequestModel
            {
                PersonId = personId
            };
            var json = System.Text.Json.JsonSerializer.Serialize(person);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(urlWithMethod, content).Result;

            string result = response.Content.ReadAsStringAsync().Result;
            var resp = JsonConvert.DeserializeObject<Person>(result);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "İşlem yapılırken bir hata oluştu";
            }
            else if (resp.UUID == 0)
            {
                return "Kayıt silinirken bir hata oluştu."+personId+" ye ait bir Kişi bulunamamıştır.";
            }
            _phoneDictionaryService.DeletePerson(resp.UUID);
            return "Kayıt başarıyla silinmiştir.";
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
        public Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId)
        {
            return _phoneDictionaryService.RemoveContactInfoById(personId, infoTypeId);
        }
    }
    
}
