using System;
using System.Text;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.DAL.Repositories;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace MeetingWebsite.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddDbContext<MeetingDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MeetingDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors();
            services.AddMvc().AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    ((DefaultContractResolver)resolver).NamingStrategy = null;
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JwT_Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            })
                //.AddFacebook("Facebook", options =>
                //{
                //    options.AppSecret = "bb60ddb9db71cca56972fa6f6b3d8fb5";
                //    options.AppId = "241399096724373";
                //})
                .AddGoogle("Google", options =>
                {
                    options.CallbackPath = new PathString("/signin-google");
                    options.ClientId = "526768688788-7b660hm931dfann35p93pn34cle8h2r6.apps.googleusercontent.com";
                    options.ClientSecret = "KRVsEMbicD2sfWFLxHri6rjg";
                });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.Use(async (ctx, next) =>
            //{
            //    await next();
            //    if (ctx.Response.StatusCode == 204)
            //    {
            //        ctx.Response.ContentLength = 0;
            //    }
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next();

            //    context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            //    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,PATCH,OPTIONS");

            //    if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            //    {
            //        context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            //    }

            //    if (context.Request.Method?.ToUpperInvariant() == "OPTIONS")
            //    {
            //        context.Response.StatusCode = 200;
            //        await context.Response.WriteAsync("");
            //    }
            //    else
            //    if (context.Response.StatusCode == 404 &&
            //        !Path.HasExtension(context.Request.Path.Value) &&
            //        !context.Request.Path.Value.StartsWith("/api/"))
            //    {
            //        context.Response.StatusCode = 200;
            //        context.Response.ContentType = "text/html";
            //        await context.Response.SendFileAsync(Path.Combine(env.WebRootPath, "index.html"));
            //    }
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options =>
            options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}
