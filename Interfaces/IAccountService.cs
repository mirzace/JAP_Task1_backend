using api.DTOs;
using api.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IAccountService
    {
        Task<ServerResponse<GetUserDto>> Register(RegisterDto registerDto);
        Task<ServerResponse<GetUserDto>> Login(LoginDto loginDto);
    }
}
