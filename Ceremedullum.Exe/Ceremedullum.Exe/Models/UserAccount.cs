using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceremedullum.Exe.Models
{
    public sealed class UserAccount
    {
        private static readonly Lazy<UserAccount>
            Lazy =
                new Lazy<UserAccount>
                    (() => new UserAccount());

        public static UserAccount Instance => Lazy.Value;

        private string UserName { get; set; }
        private string Password { get; set; }
        private string Token { get; set; }

        public UserAccount()
        {

        }

        public void SetUser(string username, string password)
        {
           this.UserName = username;
           this.Password = password;
        }
    }
}
}
