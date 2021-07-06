using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models.PatientModels
{
    public interface IPatientInfo
    {
        int PatientId { get; set; }
        char Sex { get; set; }
        int BirthYear {  get; set; }
        IList<IVisitInfo> PatientHistory { get; set; }
        IList<IDiseases> Diseases { get; set; }
        IDictionary<IVisitInfo, IDiseases> VisitMap { get; set; }
    }
}
