using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class RegisterDto
    {
        [Required] public string UserName { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
