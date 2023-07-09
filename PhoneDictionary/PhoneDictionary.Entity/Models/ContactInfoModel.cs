using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneDictionary.Entity.ContactInfo;

namespace PhoneDictionary.Entity.Models
{
    public class ContactInfoModel : BaseEntity
    {
        public InfoTypes InfoTypes  { get; set; }
        public string Content { get; set; }
    }
}
