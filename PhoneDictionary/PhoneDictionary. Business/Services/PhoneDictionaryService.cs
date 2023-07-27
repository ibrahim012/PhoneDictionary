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

        public Person AddContactInfo(ContactInfoModel contactInfo, int personId)
        {
            if (personId>0)
            {
                return _phoneDictionaryRepository.AddContactInfo(contactInfo, personId);
            }
            else
            {
                throw new Exception("PersonId 0dan küçük olamaz");
            }
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
            else
            {
                throw new Exception("PersonId 0dan büyük olmalıdır.");
            }
        }

        public List<PersonDetailModel> GetAllPerson()
        {
            var response = _phoneDictionaryRepository.GetAllPerson();
            return response;
        }

        public List<PersonDetailModel> GetPersonById(int personId)
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

        public int GetPersonCountByLocationName(string locationName)
        {
            if (!string.IsNullOrEmpty(locationName))
            {
                return _phoneDictionaryRepository.GetPersonCountByLocationName(locationName);
            }
            throw new Exception("Lokasyon bilgisi boş olamaz");
        }

        public int GetPhoneNumberCountByLocationName(string locationName)
        {
            if (!string.IsNullOrEmpty(locationName))
            {
                return _phoneDictionaryRepository.GetPhoneNumberCountByLocationName(locationName);
            }
            throw new Exception("Lokasyon bilgisi boş olamaz");
        }

        public Person RemoveAllContactInfoById(int personId)
        {
            return _phoneDictionaryRepository.RemoveAllContactInfoById(personId);
        }

        public Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId)
        {
            return _phoneDictionaryRepository.RemoveContactInfoById(personId, infoTypeId);
        }

        public Person UpdatePerson(PersonModel person)
        {
            return _phoneDictionaryRepository.UpdatePerson(person);
        }
    }
}
