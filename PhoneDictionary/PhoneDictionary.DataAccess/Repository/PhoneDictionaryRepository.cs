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
        public Person AddContactInfo(ContactInfoModel contactInfo, int personId)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var cInfo = new ContactInfo()
                {
                    Content = contactInfo.Content,
                    PersonUUID = personId,
                    InfoType = contactInfo.InfoTypes
                };
                dbContext.Contacts.Add(cInfo);
                dbContext.SaveChanges();

                return dbContext.Person.Find(personId);
            }
        }

        public string AddReport(List<RabbitMQReportModel> model)
        {
            try
            {
                using (var dbContext = new PhoneDictionaryDbContext())
                {
                    foreach (var item in model)
                    {
                        var report = new Report()
                        {
                            Content = item.Result.ToString(),
                            CreatedDate = DateTime.Now,
                            ReportParameterValue = item.ParameterValue,
                            IsActive = true,
                            InfoType = item.ReportType
                        };
                        dbContext.Report.Add(report);
                    }
                    dbContext.SaveChanges();
                    return "OK";
                }
            }
            catch (Exception)
            {
                return "Hata";
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

                var contacts = dbContext.Contacts.Where(x => x.PersonUUID == personId).ToList();

                foreach (var item in contacts)
                {
                    item.IsActive = false;
                    item.UpdatedDate = DateTime.Now;
                    dbContext.Contacts.Update(item);
                }

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
                person = dbContext.Person.Include(x => x.ContactInfos).Where(x => x.UUID == personId).ToList();
            }

            return new Mapping().PersonToPersonDetailDTOList(person);

        }

        public int GetPersonCountByLocationName(string locationName)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var contactInfos = dbContext.Contacts.Where(x => x.Content == locationName && x.InfoType == ContactInfo.InfoTypes.Location).Select(x => x.PersonUUID).ToArray();
                return dbContext.Person.Where(x=>contactInfos.Contains(x.UUID)).ToList().Count();
            }
        }

        public int GetPhoneNumberCountByLocationName(string locationName)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var contactInfos = dbContext.Contacts.Where(x => x.Content == locationName && x.InfoType == ContactInfo.InfoTypes.Location).Select(x=>x.PersonUUID).ToArray();
                return dbContext.Contacts.Where(x => contactInfos.Contains(x.PersonUUID) && x.InfoType == ContactInfo.InfoTypes.PhoneNumber).ToList().Count;
            }
        }

        public Person RemoveAllContactInfoById(int userId)
        {
            var person = new Person();
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var contactInfos = dbContext.Contacts.Where(x=>x.PersonUUID == userId).ToList();

                if (contactInfos == null || contactInfos.Count==0)
                {
                    return person;
                }
                foreach (var contact in contactInfos)
                {
                    contact.IsActive = false;
                    contact.UpdatedDate = DateTime.Now;
                    dbContext.Contacts.Update(contact);
                    dbContext.SaveChanges();

                }
                return dbContext.Person.Find(userId);
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

        public Person UpdatePerson(PersonModel person)
        {
            using (var dbContext = new PhoneDictionaryDbContext())
            {
                var currPerson = dbContext.Person.Find(person.UUID);

                if (currPerson != null)
                {
                    if (!string.IsNullOrEmpty(person.Surname))
                        currPerson.Surname = person.Surname;


                    if (!string.IsNullOrEmpty(person.Name))
                        currPerson.Name = person.Name;


                    if (!string.IsNullOrEmpty(person.CompanyName))
                        currPerson.CompanyName = person.CompanyName;

                    dbContext.Person.Update(currPerson);
                    dbContext.SaveChanges();

                    return dbContext.Person.Find(person.UUID);
                }

                return new Person();


            }
        }
    }
}
