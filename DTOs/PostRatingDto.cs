using api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class PostRatingDto
    {
        public int Rate { get; set; }
        public int ScreenplayId { get; set; }
    }
}
