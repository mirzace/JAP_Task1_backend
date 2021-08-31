using api.DTOs;
using api.Entities;
using api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IScreenplayRepository
    {
        Task<PagedList<GetScreenplayDto>> GetScreenplaysAsync(ScreenplayParams screenplayParams);
        Task<GetScreenplayDto> GetScreenplayByIdAsync(int id);
    }
}
