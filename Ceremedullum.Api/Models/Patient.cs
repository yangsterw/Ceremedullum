using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceremedullum.Api.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public char Sex { get; set; }
        public int BirthYear { get; set; }
        public List<PatientVisitInfo> PatientHistory { get; set; }
        public List<Diseases> Diseases { get; set; }
        public Dictionary<PatientVisitInfo, Diseases> VisitMap { get; set; }
    }
}
