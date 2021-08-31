using api.Entities;
using api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IScreenplayService
    {
        Task<ServerResponse<IEnumerable<Screenplay>>> GetScreenplays();
        Task<ServerResponse<Screenplay>> GetScreenplayById(int id);
    }
}
