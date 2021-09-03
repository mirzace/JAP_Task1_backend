using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class GetUserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
