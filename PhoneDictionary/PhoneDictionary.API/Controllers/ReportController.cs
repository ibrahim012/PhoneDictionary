using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneDictionary._Business.Services;
using PhoneDictionary.Entity.APIModel;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Models;
using System.Net;
using System.Text;

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
        public async Task<string> GetPersonCountByLocationName(string locationName)
        {
            if (string.IsNullOrEmpty(locationName))
            {
                return "Rapor oluşturmak için lütfen lokasyon bilgisi giriniz!";
            }
            try
            {
                var baseUrl = "https://localhost:7288/";
                var urlWithMethod = "api/ContactInfo/GetPersonCountByLocationName";

                var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var req = new ReportRequestModel
                {
                    LocationName = locationName
                };
                var json = System.Text.Json.JsonSerializer.Serialize(req);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(urlWithMethod, content).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                return "İşlem başarılı. Rapor queueya gönderilmiştir.";

            }
            catch (Exception ex)
            {
                return "Bir hata oluştu!"+ex.Message;
            }
        }

        [HttpGet("GetPhoneNumberCountByLocationName")]
        public string GetPhoneNumberCountByLocationName(string locationName)
        {
            if (string.IsNullOrEmpty(locationName))
            {
                return "Rapor oluşturmak için lütfen lokasyon bilgisi giriniz!";
            }
            try
            {
                var baseUrl = "https://localhost:7288/";
                var urlWithMethod = "api/ContactInfo/GetPhoneNumberCountByLocationName";

                var client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var req = new ReportRequestModel
                {
                    LocationName = locationName
                };
                var json = System.Text.Json.JsonSerializer.Serialize(req);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(urlWithMethod, content).Result;

                string result = response.Content.ReadAsStringAsync().Result;

                return "İşlem başarılı. Rapor queueya gönderilmiştir.";

            }
            catch (Exception ex)
            {
                return "Bir hata oluştu!" + ex.Message;
            }
        }

        

    }
}
