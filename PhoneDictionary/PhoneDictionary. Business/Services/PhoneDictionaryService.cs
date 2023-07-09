using PhoneDictionary.DataAccess.Repository;
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
    public class PhoneDictionaryService : IPhoneDictionaryService
    {
        private IPhoneDictionaryRepository _phoneDictionaryRepository;

        public PhoneDictionaryService()
        {
            _phoneDictionaryRepository = new PhoneDictionaryRepository();
        }

        public Person AddContactInfo(ContactInfo contactInfo, int personId)
        {
            return _phoneDictionaryRepository.AddContactInfo(contactInfo, personId);
        }

        public PersonModel CreatePerson(PersonModel person)
        {
            if (person != null)
            {
                return _phoneDictionaryRepository.CreatePerson(person);
            }
            throw new Exception("Model boş olamaz");
        }

        public void DeletePerson(int personId)
        {
            if (personId>0)
            {
                _phoneDictionaryRepository.DeletePerson(personId);
            }
            throw new Exception("PersonId 0dan büyük olmalıdır.");
        }

        public List<Person> GetAllPerson()
        {
            var response = _phoneDictionaryRepository.GetAllPerson();
            return response;
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

        public Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId)
        {
            return _phoneDictionaryRepository.RemoveContactInfoById(personId, infoTypeId);
        }

        public Person UpdatePerson(Person person)
        {
            return _phoneDictionaryRepository.UpdatePerson(person);
        }
    }
}
