using api.DTOs;
using api.Entities;
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
    public class ScreenplayController : BaseApiController
    {
        private readonly IScreenplayService _screenplayService;
        public ScreenplayController(IScreenplayService screenplayService)
        {
            _screenplayService = screenplayService;
        }

        [HttpGet]
        public async Task<ActionResult<ServerResponse<GetScreenplayDto>>> Get([FromQuery] ScreenplayParams screenplayParams)
        {
            return Ok(await _screenplayService.GetScreenplays(screenplayParams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServerResponse<GetScreenplayDto>>> GetSingle(int id)
        {
            return Ok(await _screenplayService.GetScreenplayById(id));
        }
    }
}
