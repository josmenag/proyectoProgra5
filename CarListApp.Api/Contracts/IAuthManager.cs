using System;
using CarListApp.Api.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace CarListApp.Api.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
    }
}

