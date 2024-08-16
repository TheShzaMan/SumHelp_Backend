using FullStackAuth_WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullStackAuth_WebAPI.Contracts
{
    public interface IAuthenticationManager
    {
        Task<string> CreateToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken);
        Task<TokenDto> Refresh(TokenDto tokenDto);
        string GenerateRefreshToken();
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
    }
}
