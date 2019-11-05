using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models
{
    public sealed class UserAccount : IUserAccount
    {
        private static readonly Lazy<UserAccount>
            Lazy =
                new Lazy<UserAccount>
                    (() => new UserAccount());

        public static UserAccount Instance => Lazy.Value;

        public int id { get; set; }
        public string firstName { get; set; } 
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string token { get; set; }

        public int doctorId { get; set; }


        public UserAccount()
        {

        }

        public void SetUser(string username, string passwd, string tken)
        {
            this.userName = username;
            this.password = passwd;
            this.token = tken;
        }
    }
}

