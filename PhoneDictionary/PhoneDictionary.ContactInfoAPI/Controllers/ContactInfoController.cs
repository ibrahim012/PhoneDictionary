using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.APIModel;
using PhoneDictionary.Entity.Models;
using System.Net;
using System.Text;

namespace PhoneDictionary.ContactInfoAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[Controller]")]
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

        [HttpPost("GetPhoneNumberCountByLocationName")]
        public string GetPhoneNumberCountByLocationName([FromBody] ReportRequestModel model)
        {
            if (string.IsNullOrEmpty(model.LocationName))
            {
                return "Rapor oluşturmak için lütfen lokasyon bilgisi giriniz!";
            }
            var rbmqModel = new RabbitMQReportModel
            {
                ParameterValue = model.LocationName,
                Result = 1,
                ReportType = Report.ReportTypes.NumberOfPhoneNumbersInTheLocation
            };
            RabbitMQPublisher.Publisher(rbmqModel);
            return "OK";
        }

        [HttpPost("GetPersonCountByLocationName")]
        public int GetPersonCountByLocationName([FromBody] ReportRequestModel model)
        {
            var resp = _phoneDictionaryService.GetPersonCountByLocationName(model.LocationName);
            //rapor oluştuktan sonra rbmq ya mesajı publish yapacak
            var rbmqModel = new RabbitMQReportModel
            {
                ParameterValue = model.LocationName,
                Result = resp,
                ReportType = Report.ReportTypes.NumberOfPeopleInTheLocation
            };
            RabbitMQPublisher.Publisher(rbmqModel);
            return 1;
        }
    } 
}
