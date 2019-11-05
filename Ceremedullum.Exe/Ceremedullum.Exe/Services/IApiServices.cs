using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Services
{
    public interface IApiServices
    {
        Task RequestToken(string username, string password);
    }
}
