using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Entity;
using PhoneDictionary.Entity.Mapping;
using PhoneDictionary.Entity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.DataAccess.Repository
{
    public class PhoneDictionaryRepository : IPhoneDictionaryRepository
    {
        public Person AddContactInfo(ContactInfo contactInfo, int personId)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                dbContext.Contacts.Add(contactInfo);
                dbContext.SaveChanges();

                return dbContext.Person.Find(contactInfo.PersonUUID);
            }
        }

        public PersonModel CreatePerson(PersonModel person)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                Person p = new Person
                {
                    CompanyName = person.CompanyName,
                    Name = person.Name,
                    Surname = person.Surname
                };

                dbContext.Person.Add(p);
                dbContext.SaveChanges();
                return person;
            }
        }

        public void DeletePerson(int personId)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var person = dbContext.Person.Find(personId);
                person.IsActive = false;
                person.UpdatedDate = DateTime.Now;
                dbContext.Person.Update(person);
                dbContext.SaveChanges();
            }
        }

        public List<PersonDetailModel> GetAllPerson()
        {
            List<Person> person = new List<Person>();

            using (var dbContext = new PhoneDictionaryDbContext())
            {
                person = dbContext.Person.Include(x => x.ContactInfos).ToList();
            }

            return new Mapping().PersonToPersonDetailDTOList(person);
        }
        public List<PersonDetailModel> GetPersonById(int personId)
        {
            List<Person> person = new List<Person>();
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                person = dbContext.Person.Include(x => x.ContactInfos).Where(x=>x.UUID == personId).ToList();
            }

            return new Mapping().PersonToPersonDetailDTOList(person);

        }

        public Person RemoveContactInfoById(int personId, ContactInfo.InfoTypes infoTypeId)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var contact = dbContext.Contacts.Find(personId);
                contact.IsActive = false;
                contact.UpdatedDate = DateTime.Now;
                dbContext.Contacts.Update(contact);
                dbContext.SaveChanges();

                var person = dbContext.Person.Find(personId);
                return person;
            }
        }

        public Person UpdatePerson(Person person)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                dbContext.Person.Update(person);
                dbContext.SaveChanges();
                return person;
            }
        }
    }
}
