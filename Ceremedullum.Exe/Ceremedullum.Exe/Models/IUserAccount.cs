using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models
{
    public interface IUserAccount
    {
        int id {  get; set; }
        string firstName { get; set; }
        string lastName {  get; set; }
        string userName {  get; set; }
        string password {  get; set; }
        string token {  get; set; }
        int doctorId { get; set; }

        void SetUser(string username, string password, string token);
    }
}
