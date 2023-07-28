using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary.Entity.Models
{
    public class RabbitMQReportModel
    {
        public string ParameterValue { get; set; }
        public int Result { get; set; }
        public Report.ReportTypes ReportType { get; set; }
    }
}
