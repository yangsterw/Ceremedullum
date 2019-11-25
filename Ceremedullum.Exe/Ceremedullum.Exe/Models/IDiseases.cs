using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models
{
    public interface IDiseases
    {
        int DiseaseId { get; set; }
        string DiseaseName { get; set; }
    }
}
