using api.Entities;
using api.Interfaces;
using AutoMapper;
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
        public async Task<Screenplay> GetScreenplayByIdAsync(int id)
        {
            return await _context.Screenplays.FindAsync(id);
        }

        public async Task<IEnumerable<Screenplay>> GetScreenplaysAsync()
        {
            return await _context.Screenplays.ToListAsync();
        }
    }
}
