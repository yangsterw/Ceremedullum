using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceremedullum.Api.Models
{
    public class PatientInfo
    {
        public string PatientId { get; set; }
        public List<PatientHistory> PatientHistories { get; set; }

    }
}
