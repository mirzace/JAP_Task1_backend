using api.DTOs;
using api.Entities;
using api.Interfaces;
using api.Middlewares;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServerResponse<GetUserDto>>> Register(RegisterDto registerDto)
        {
            var response = await _accountService.Register(registerDto);

            Response.StatusCode = response.StatusCode;
            return response;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServerResponse<GetUserDto>>> Login(LoginDto loginDto)
        {
            var response = await _accountService.Login(loginDto);

            Response.StatusCode = response.StatusCode;
            return response;
        }

        [Authorize(Policy = "RequireConsumerRole")]
        [HttpGet("protected-resource")]
        public async Task<ActionResult<ServerResponse<string>>> GetProtectedResources()
        {
            return Ok(new ServerResponse<string>
            {
                StatusCode = 200,
                Data = "This is protected message from the server!"
            });
        }
    }
}
