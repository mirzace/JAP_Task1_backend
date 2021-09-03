using api.DTOs;
using api.Entities;
using api.Interfaces;
using api.Middlewares;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _singInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> singInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<ServerResponse<GetUserDto>> Register(RegisterDto registerDto)
        {
            var response = new ServerResponse<GetUserDto>();

            try
            {
                if (await UserExists(registerDto.UserName)) {
                    response.Success = false;
                    response.Message = "Username is taken!";
                    return response;
                }

                var user = _mapper.Map<AppUser>(registerDto);

                user.UserName = registerDto.UserName.ToLower();

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (!result.Succeeded) {
                    response.Success = false;
                    response.Message = result.Errors.ToString();
                    return response;
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Consumer");
                if (!roleResult.Succeeded)
                {
                    response.Success = false;
                    response.Message = roleResult.Errors.ToString();
                    return response;
                }

                response.Data = new GetUserDto
                {
                    UserName = user.UserName,
                    Token = await _tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServerResponse<GetUserDto>> Login(LoginDto loginDto)
        {
            var response = new ServerResponse<GetUserDto>();

            try
            {
                var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

                if (user == null) {
                    response.Success = false;
                    response.Message = "Invalid Username";
                    return response;
                }

                var result = await _singInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!result.Succeeded)
                {
                    response.Success = false;
                    response.Message = "Unauthorized";
                    return response;
                }

                response.Data = new GetUserDto
                {
                    UserName = user.UserName,
                    Token = await _tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
