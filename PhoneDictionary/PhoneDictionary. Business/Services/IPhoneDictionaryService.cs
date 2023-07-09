using PhoneDictionary.Entity;
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
        Person CreatePerson(Person person);
        void DeletePerson(int personId);
        Person UpdatePerson(Person person);
        List<Person> GetAllPerson();

        Person AddContactInfo(ContactInfo contactInfo);
        Person RemoveContactInfoById(int userId, ContactInfo.InfoTypes infoTypeId);
        Person GetPersonById(int personId);
    }
}
