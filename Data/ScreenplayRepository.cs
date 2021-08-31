using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

            query = screenplayParams.OrderBy switch
            {
                "releaseDate" => query.OrderByDescending(s => s.ReleaseDate),
                _ => query.OrderByDescending(s => s.Title)
            };

            return await PagedList<GetScreenplayDto>.CreateAsync(
                query.ProjectTo<GetScreenplayDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                screenplayParams.PageNumber, screenplayParams.PageSize);
        }
    }
}
