using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity
{
    public class ContactInfo : BaseEntity
    {
        public enum InfoTypes { PhoneNumber = 1, EmailAddress = 2, Location = 3 }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public InfoTypes InfoType { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(Person))]
        public int PersonUUID { get; set; }
        public Person Person{ get; set; }
       
    }
}
