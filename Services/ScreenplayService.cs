using api.Entities;
using api.Interfaces;
using api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ScreenplayService : IScreenplayService
    {
        private readonly IScreenplayRepository _screenplayRepository;

        public ScreenplayService(IScreenplayRepository screenplayRepository)
        {
            _screenplayRepository = screenplayRepository;
        }
        public async Task<ServerResponse<Screenplay>> GetScreenplayById(int id)
        {
            var response = new ServerResponse<Screenplay>();
            var screenplay = await _screenplayRepository.GetScreenplayByIdAsync(id);
            if(screenplay == null)
            {
                response.Success = false;
                response.Message = "Screenplay not found!";
            } else
            {
                response.Data = screenplay;
            }
            return response;
        }

        public async Task<ServerResponse<IEnumerable<Screenplay>>> GetScreenplays()
        {
            var response = new ServerResponse<IEnumerable<Screenplay>>();
            response.Data = await _screenplayRepository.GetScreenplaysAsync();
            return response;
        }
    }
}
