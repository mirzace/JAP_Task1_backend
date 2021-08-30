using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Screenplay
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
