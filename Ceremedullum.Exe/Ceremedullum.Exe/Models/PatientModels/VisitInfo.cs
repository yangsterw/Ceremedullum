using Ceremedullum.Exe.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models.PatientModels
{
    public class VisitInfo : IVisitInfo
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public DateTime VisitTime { get; set; }
        public string VisitDescription { get; set; }
        
        public IList<Diseases> Diseases { get; set; }
    }
}
