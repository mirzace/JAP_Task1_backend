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
            var response = await _screenplayService.GetScreenplays(screenplayParams);
            Response.AddPaginationHeader(response.Data.CurrentPage, response.Data.PageSize, response.Data.TotalCount, response.Data.TotalPages);
            Response.StatusCode = response.StatusCode;

            switch (response.StatusCode)
            {
                case 200:
                    return Ok(response);
                case 404:
                    return NotFound(response);
                default:
                    return BadRequest(response);
            }            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServerResponse<GetScreenplayDto>>> GetSingle(int id)
        {
            var response = await _screenplayService.GetScreenplayById(id);

            Response.StatusCode = response.StatusCode;
            return response;
        }
    }
}
