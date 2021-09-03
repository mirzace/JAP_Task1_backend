using api.DTOs;
using api.Interfaces;
using api.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class RatingsController : BaseApiController
    {
        private readonly IRatingService _ratingService;
        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public async Task<ActionResult<ServerResponse<GetScreenplayDto>>> AddRating(PostRatingDto postRatingDto)
        {
            var response = await _ratingService.AddRating(postRatingDto);

            Response.StatusCode = response.StatusCode;
            return response;
        }
    }
}
