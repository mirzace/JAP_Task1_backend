using api.DTOs;
using api.Entities;
using api.Interfaces;
using api.Middlewares;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IScreenplayRepository _screenplayRepository;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IScreenplayRepository screenplayRepository,
            IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _screenplayRepository = screenplayRepository;
            _mapper = mapper;
        }
        public async Task<ServerResponse<GetScreenplayDto>> AddRating(PostRatingDto postRatingDto)
        {
            var response = new ServerResponse<GetScreenplayDto>();

            try
            {
                // Check if rate is between 1 and 5
                if (postRatingDto.Rate < 1 || postRatingDto.Rate > 5)
                {
                    response.Success = false;
                    response.StatusCode = 400;
                    response.Message = "Rate must be between 1 and 5!";
                    return response;
                }

                var screenplay = await _screenplayRepository.GetScreenplayAsync(postRatingDto.ScreenplayId);
                if (screenplay == null)
                {
                    response.Success = false;
                    response.StatusCode = 404;
                    response.Message = "Screenplay not found!";
                    return response;
                }

                Rating rating = new Rating
                {
                    Screenplay = screenplay,
                    Rate = postRatingDto.Rate
                };
                _ratingRepository.AddRating(rating);

                var ratedScreenplay = await _screenplayRepository.GetScreenplayByIdAsync(postRatingDto.ScreenplayId);

                response.Data = _mapper.Map<GetScreenplayDto>(ratedScreenplay);
                response.StatusCode = 201;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
