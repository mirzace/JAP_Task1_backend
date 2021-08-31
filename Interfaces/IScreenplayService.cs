using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IScreenplayService
    {
        Task<ServerResponse<PagedList<GetScreenplayDto>>> GetScreenplays(ScreenplayParams screenplayParams);
        Task<ServerResponse<GetScreenplayDto>> GetScreenplayById(int id);
    }
}
