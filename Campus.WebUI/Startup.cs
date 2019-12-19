using Campus.Application.Groups.Commands.CreateGroup;
using Campus.Application.Groups.Queries.GetAllGroups;
using Campus.Application.Infrastructure;
using Campus.Infrastructure.Helpers;
using Campus.Infrastructure.Helpers.Interfaces;
using Campus.Persistence;
using Campus.WebUI.Filters;
using Campus.WebUI.Identity.Jwt;
using Campus.WebUI.Identity.Jwt.Extensions;
using Campus.WebUI.Options;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Campus.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CampusDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CampusDatabase")));

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetAllGroupsQueryHandler).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPasswordHasher), typeof(PasswordHasher));
            services.AddTransient(typeof(IPasswordGenerator), typeof(PasswordGenerator));           

            services
               .AddControllers(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
               .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
               .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateGroupCommandValidator>());

            var section = Configuration.GetSection("AuthOptions");
            var authOptions = section.Get<AuthOptions>();
            var jwtOptions = new JwtOptions(authOptions.Audience, authOptions.Issuer, authOptions.Secret,
                                            authOptions.Lifetime);
            services.AddApiJwtAuthentication(jwtOptions);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            /*  if (env.IsDevelopment())
                  app.UseCors(x => x
                      .WithOrigins("https://localhost:3000")
                      .AllowCredentials()
                      .AllowAnyMethod()
                      .AllowAnyHeader());*/

            app.UseSecureJwt();
            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
