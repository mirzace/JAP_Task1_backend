using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Screenplay> Screenplays { get; set; }

    }
}
