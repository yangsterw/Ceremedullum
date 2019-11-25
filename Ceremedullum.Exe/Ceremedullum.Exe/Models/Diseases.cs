using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models
{
    public class Diseases : IDiseases
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
    }
}
