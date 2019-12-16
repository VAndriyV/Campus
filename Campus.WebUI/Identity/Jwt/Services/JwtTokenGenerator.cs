using Campus.Application.Users.Queries.DataTransferObjects;
using Campus.WebUI.Identity.Jwt.Interfaces;
using Campus.WebUI.Identity.Jwt.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Campus.WebUI.Identity.Jwt.Services
{
    public sealed class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _tokenOptions;
        public JwtTokenGenerator(JwtOptions tokenOptions)
        {
            _tokenOptions = tokenOptions ??
                            throw new ArgumentNullException(
                                $"An instance of valid {nameof(JwtOptions)} must be passed in order to generate a JWT!");
        }

        public JwtTokenResult Generate(UserDto user)
        {
            var expiration = TimeSpan.FromMinutes(_tokenOptions.TokenExpiryInMinutes);
            var claimsIdentity = BuildClaims(user);

            var jwt = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claimsIdentity.Claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(expiration),
                new SigningCredentials(
                    _tokenOptions.SigningKey,
                    SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtTokenResult
            {
                AccessToken = accessToken,
                Expires = expiration
            };
        }

        private ClaimsIdentity BuildClaims(UserDto user)
        {
            var roleClaims = user.Roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)).ToList();

            var defaultClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.TimeOfDay.Ticks.ToString(),
                    ClaimValueTypes.Integer64)
            };

            var claims = defaultClaims.Concat(roleClaims);

            return new ClaimsIdentity(claims, "token");
        }
    }
}
