using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceremedullum.Exe.Models.PatientModels;

namespace Ceremedullum.Exe.ViewModels
{
    public class PatientRecordViewModel
    {
        public ObservableCollection<IVisitInfo> PatientVisits { get; set; }
    }
}
