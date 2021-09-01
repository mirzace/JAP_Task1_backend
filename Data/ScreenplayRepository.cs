using api.DTOs;
using api.Entities;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public class ScreenplayRepository : IScreenplayRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ScreenplayRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetScreenplayDto> GetScreenplayByIdAsync(int id)
        {
            var query = _context.Screenplays
                 .Where(x => x.Id == id)
                 .ProjectTo<GetScreenplayDto>(_mapper.ConfigurationProvider)
                 .AsQueryable();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedList<GetScreenplayDto>> GetScreenplaysAsync(ScreenplayParams screenplayParams)
        {
            var query = _context.Screenplays.AsQueryable();
  
            query = query.Where(s => s.Category == screenplayParams.Category);

            /*
            query = screenplayParams.OrderBy switch
            {
                _ => query.OrderByDescending(s => s.Title)
            };
            */

            query = query.OrderByDescending(x => x.Ratings.Average(a => a.Rate));
            
            return await PagedList<GetScreenplayDto>.CreateAsync(
                query.ProjectTo<GetScreenplayDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                screenplayParams.PageNumber, screenplayParams.PageSize);
        }

        public async Task<Screenplay> GetScreenplayAsync(int id)
        {
            var query = _context.Screenplays
                 .Where(x => x.Id == id)
                 .AsQueryable();

            return await query.FirstOrDefaultAsync();
        }

    }
}
