using api.DTOs;
using api.Entities;
using api.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Screenplay, GetScreenplayDto>()
                .ForMember(dest => dest.AverageRate, opt => opt.MapFrom(src => src.Ratings.CalculateRate()));
            CreateMap<Actor, GetActorsDto>();
            CreateMap<PostRatingDto, Rating>();
        }
    }
}
