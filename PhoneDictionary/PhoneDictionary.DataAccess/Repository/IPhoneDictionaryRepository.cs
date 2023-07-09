using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneDictionary.Entity.ContactInfo;

namespace PhoneDictionary.DataAccess.Repository
{ 
    public interface IPhoneDictionaryRepository
    {
        PersonModel CreatePerson(PersonModel person);
        void DeletePerson(int personId);
        Person UpdatePerson(Person person);
        List<Person> GetAllPerson();

        Person AddContactInfo(ContactInfo contactInfo, int personId);
        Person RemoveContactInfoById(int userId, InfoTypes infoTypeId);
        Person GetPersonById(int personId);
    }
}
