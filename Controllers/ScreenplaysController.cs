using api.DTOs;
using api.Entities;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class ScreenplaysController : BaseApiController
    {
        private readonly IScreenplayService _screenplayService;

        public ScreenplaysController(IScreenplayService screenplayService)
        {
            _screenplayService = screenplayService;
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse<IEnumerable<GetScreenplayDto>>>> Get([FromQuery] ScreenplayParams screenplayParams)
        {
            var screenplays = await _screenplayService.GetScreenplays(screenplayParams);
            Response.AddPaginationHeader(screenplays.Data.CurrentPage, screenplays.Data.PageSize, screenplays.Data.TotalCount, screenplays.Data.TotalPages);
            
            return Ok(screenplays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServerResponse<GetScreenplayDto>>> GetSingle(int id)
        {
            return Ok(await _screenplayService.GetScreenplayById(id));
        }
    }
}
