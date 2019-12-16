using Campus.WebUI.Identity.Jwt.Interfaces;
using Campus.WebUI.Identity.Jwt.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campus.WebUI.Identity.Jwt.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiJwtAuthentication(
            this IServiceCollection services,
            JwtOptions tokenOptions)
        {
            if (tokenOptions == null)
                throw new ArgumentNullException(
                    $"{nameof(tokenOptions)} is a required parameter. " +
                    "Please make sure you've provided a valid instance with the appropriate values configured.");

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>(serviceProvider =>
                new JwtTokenGenerator(tokenOptions));           

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateAudience = false,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuer = false,
                        ValidIssuer = tokenOptions.Issuer,
                        IssuerSigningKey = tokenOptions.SigningKey,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidateLifetime = true
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
