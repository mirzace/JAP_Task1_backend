using api.DTOs;
using api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IRatingService
    {
        Task<ServerResponse<GetScreenplayDto>> AddRating(PostRatingDto postRatingDto);
    }
}
