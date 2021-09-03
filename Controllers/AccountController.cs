using api.DTOs;
using api.Entities;
using api.Interfaces;
using api.Middlewares;
using AutoMapper;
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
            return Ok(await _accountService.Register(registerDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServerResponse<GetUserDto>>> Login(LoginDto loginDto)
        {
            return Ok(await _accountService.Login(loginDto));
        }
    }
}
