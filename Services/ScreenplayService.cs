using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using api.Middlewares;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ScreenplayService : IScreenplayService
    {
        private readonly IScreenplayRepository _screenplayRepository;
        private readonly IMapper _mapper;

        public ScreenplayService(IScreenplayRepository screenplayRepository, IMapper mapper)
        {
            _screenplayRepository = screenplayRepository;
            _mapper = mapper;
        }
        public async Task<ServerResponse<GetScreenplayDto>> GetScreenplayById(int id)
        {
            var response = new ServerResponse<GetScreenplayDto>();
            try
            {
                var screenplay = await _screenplayRepository.GetScreenplayByIdAsync(id);
                if (screenplay == null)
                {
                    response.Success = false;
                    response.Message = "Screenplay not found!";
                }
                else
                {
                    response.Data = screenplay;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            
            return response;
        }

        public async Task<ServerResponse<PagedList<GetScreenplayDto>>> GetScreenplays(ScreenplayParams screenplayParams)
        {
            var response = new ServerResponse<PagedList<GetScreenplayDto>>();
            try
            {
                response.Data = await _screenplayRepository.GetScreenplaysAsync(screenplayParams);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
