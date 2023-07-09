using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity.Models
{
    public  class PersonDetailModel
    {
        public Person Person { get; set; }
        public ContactInfoModel ContactInfo { get; set; }
    }
}
