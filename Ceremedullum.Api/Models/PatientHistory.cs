using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceremedullum.Api.Models
{
    public class PatientHistory
    {
        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitInfo { get; set; }
        public string PrimaryReasonForVisit { get; set; }
        public List<string> Diseases { get; set; }
    }
}
