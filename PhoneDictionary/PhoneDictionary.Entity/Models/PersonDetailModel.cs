using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity.Models
{
    public  class PersonDetailModel
    {
        public PersonModel Person { get; set; }
        public List<ContactInfoModel> ContactInfo { get; set; }
    }
}
