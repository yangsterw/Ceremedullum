using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ceremedullum.Api.Models
{
    public class UserInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;}
    }
}
