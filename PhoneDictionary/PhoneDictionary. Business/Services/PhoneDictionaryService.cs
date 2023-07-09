using PhoneDictionary.DataAccess.Repository;
using PhoneDictionary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneDictionary.Entity.ContactInfo;

namespace PhoneDictionary._Business.Services
{
    public class PhoneDictionaryService : IPhoneDictionaryService
    {
        private IPhoneDictionaryRepository _phoneDictionaryRepository;

        public PhoneDictionaryService()
        {
            _phoneDictionaryRepository = new PhoneDictionaryRepository();
        }

        public Person AddContactInfo(ContactInfo contactInfo)
        {
            throw new NotImplementedException();
        }

        public Person CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAllPerson()
        {
            return _phoneDictionaryRepository.GetAllPerson();
        }

        public Person GetPersonById(int personId)
        {
            if (personId>0)
            {
                return _phoneDictionaryRepository.GetPersonById(personId);
            }
            else
            {
                throw new Exception("PersonID 0'dan küçük olamaz");
            }
        } 

        public Person RemoveContactInfoById(int userId, ContactInfo.InfoTypes infoTypeId)
        {
            throw new NotImplementedException();
        }

        public Person UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
