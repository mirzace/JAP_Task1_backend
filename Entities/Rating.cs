using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        [Required]
        public Screenplay Screenplay { get; set; }
    }
}
