using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Entity;
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

        public List<Person> GetAllPerson()
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var response = dbContext.Person.Include(x => x.ContactInfos).ToList();
                return response;
            }
        }
        public Person GetPersonById(int personId)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                return dbContext.Person.Find(personId);
            }
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
