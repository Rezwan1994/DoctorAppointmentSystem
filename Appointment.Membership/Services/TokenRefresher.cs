using Appointment.Common;
using Appointment.Membership.Entities;
using Appointment.Membership.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Membership.Services
{
    public class TokenRefresher:ITokenRefresher
    {
        private IConfiguration _configuration;
        private readonly IRefreshTokenGeneratorService _refreshTokenGeneratorService;
        private Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        public TokenRefresher(IConfiguration configuration, IRefreshTokenGeneratorService refreshTokenGeneratorService, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _refreshTokenGeneratorService = refreshTokenGeneratorService;
            _userManager = userManager;
        }
        public async Task<AuthorizeResponse> AuthenticateAsync(ApplicationUser user, Claim[] claims)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt").GetValue<string>("Key"));
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var refreshToken = await _refreshTokenGeneratorService.GenerateRefreshToken();
            if (string.IsNullOrEmpty(user.RefreshToken))
            {
                user.RefreshToken = refreshToken;
                await _userManager.UpdateAsync(user);
            }
            return new AuthorizeResponse
            {
                JwtToken = token,
                RefreshToken = refreshToken,

            };
        }
        public async Task<AuthorizeResponse> Refresh(RefreshCred refreshCred)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            var principle =  tokenHandler.ValidateToken(refreshCred.JwtToken,
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt").GetValue<string>("Key")))

                }, out validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                throw new SecurityTokenException("Invalied Token Passed!");
            }
          
            var user = await _userManager.FindByNameAsync(principle.Identity?.Name);
             return await AuthenticateAsync(user, principle.Claims.ToArray());
           
        }
    }
}
