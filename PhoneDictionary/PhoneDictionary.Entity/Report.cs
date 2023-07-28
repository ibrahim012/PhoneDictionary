using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity
{
    public class Report : BaseEntity
    {
        public enum ReportTypes { NumberOfPeopleInTheLocation =1,NumberOfPhoneNumbersInTheLocation=2 }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ReportTypes InfoType { get; set; }
        [StringLength(100)]
        public string ReportParameterValue { get; set; }
        public string Content { get; set; }

    }
}
