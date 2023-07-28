using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneDictionary.Entity.ContactInfo;

namespace PhoneDictionary._Business.Services
{
    public interface IPhoneDictionaryService
    {
        PersonModel CreatePerson(PersonModel person);
        void DeletePerson(int personId);
        Person UpdatePerson(PersonModel person);
        List<PersonDetailModel> GetAllPerson();

        Person AddContactInfo(ContactInfoModel contactInfo, int personId);
        Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId);
        List<PersonDetailModel> GetPersonById(int personId);
        public int GetPersonCountByLocationName(string locationName);
        public int GetPhoneNumberCountByLocationName(string locationName);

        Person RemoveAllContactInfoById(int personId);
        string AddReport(RabbitMQReportModel model);
    }
}
