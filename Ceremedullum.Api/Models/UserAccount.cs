using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceremedullum.Api.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HashCode { get; set; }
        public string SaltCode { get; set; }
        public string Token { get; set; }
        public int DoctorId { get; set; }
    }
}
