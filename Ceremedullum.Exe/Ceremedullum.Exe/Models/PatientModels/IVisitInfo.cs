using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models.PatientModels
{
    public interface IVisitInfo
    {
        int PatientId { get; set; }
        DateTime VisitDate { get; set; }
        DateTime VisitTime { get; set; }
        String VisitDescription { get; set; }
        IList<Diseases> Diseases { get; set; }
    }
}
