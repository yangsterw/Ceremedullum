using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceremedullum.Api.Models
{
    public class PatientVisitInfo
    {
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime VisitTime { get; set; }
        public String VisitDescription { get; set; }
        public List<Diseases> Diseases { get; set; }
    }
}
