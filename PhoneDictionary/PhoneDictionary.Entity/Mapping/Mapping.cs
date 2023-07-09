using PhoneDictionary.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity.Mapping
{
    public class Mapping
    {
        public List<PersonDetailModel> PersonToPersonDetailDTOList(List<Person> person)
        {
            List<PersonDetailModel> response = new List<PersonDetailModel>();

            foreach (var item in person)
            {
                var personDetailModel = new PersonDetailModel();

                PersonModel p = new PersonModel
                {
                    CompanyName = item.CompanyName,
                    Name = item.Name,
                    Surname = item.Surname,
                    CreatedDate = item.CreatedDate,
                    IsActive = item.IsActive,
                    UpdatedDate = item.UpdatedDate
                };
                personDetailModel.Person = p;

                List<ContactInfoModel> tempInfoModels = new List<ContactInfoModel>();
                foreach (var item2 in item.ContactInfos)
                {
                    ContactInfoModel c = new ContactInfoModel()
                    {
                        UpdatedDate = item2.UpdatedDate,
                        IsActive = item2.IsActive,
                        CreatedDate = item2.CreatedDate,
                        Content = item2.Content,
                        InfoTypes = item2.InfoType
                    };
                    tempInfoModels.Add(c);
                }
                personDetailModel.ContactInfo = tempInfoModels;

                response.Add(personDetailModel);
            }
            return response;
        }
    }
}
