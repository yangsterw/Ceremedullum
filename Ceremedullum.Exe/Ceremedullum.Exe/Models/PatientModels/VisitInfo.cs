using Ceremedullum.Exe.Models.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models.PatientModels
{
    class VisitInfo : IVisitInfo
    {
        public int PatientId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime VisitDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime VisitTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string VisitDescription { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<Diseases> Diseases { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
