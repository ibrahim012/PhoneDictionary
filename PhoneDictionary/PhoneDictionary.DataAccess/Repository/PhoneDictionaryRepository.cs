using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Entity;
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
        public Person AddContactInfo(ContactInfo contactInfo)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                dbContext.Contacts.Add(contactInfo);
                dbContext.SaveChanges();

                return dbContext.Person.Find(contactInfo.PersonUUID);
            }
        }

        public Person CreatePerson(Person person)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                dbContext.Person.Add(person);
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
