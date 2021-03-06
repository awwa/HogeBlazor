using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HogeBlazor.Shared.Models.Db;
using Microsoft.IdentityModel.Tokens;

namespace HogeBlazor.Server.Helpers;

public interface ITokenService
{
    SigningCredentials GetSigningCredentials();
    Task<List<Claim>> GetClaims(User user);
    JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}