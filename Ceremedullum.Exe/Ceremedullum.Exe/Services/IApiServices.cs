using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceremedullum.Exe.Models;

namespace Ceremedullum.Exe.Services
{
    public interface IApiServices
    {
        Task<UserAccount> RequestToken(string username, string password);
    }
}
