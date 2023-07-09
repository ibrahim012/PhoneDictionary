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
        Person UpdatePerson(Person person);
        List<PersonDetailModel> GetAllPerson();

        Person AddContactInfo(ContactInfo contactInfo,int personId);
        Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId);
        List<PersonDetailModel> GetPersonById(int personId);
    }
}
