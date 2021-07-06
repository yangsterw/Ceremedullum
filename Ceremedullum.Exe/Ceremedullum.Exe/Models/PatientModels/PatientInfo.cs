using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models.PatientModels
{
    public class PatientInfo : IPatientInfo
    {
        public int PatientId { get ; set ; }
        public char Sex { get ; set ; }
        public int BirthYear { get ; set ; }
        public IList<IVisitInfo> PatientHistory { get ; set ; }
        public IList<IDiseases> Diseases { get ; set ; }
        public IDictionary<IVisitInfo, IDiseases> VisitMap { get ; set ; }
    }
}
