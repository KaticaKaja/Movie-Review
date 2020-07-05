using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieReview.Application;
using MovieReview.EfDataAccess;
using AutoMapper;
using MovieReview.Implementation.Validators;
using MovieReview.Api.Core;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;
using MovieReview.Application.Commands;
using MovieReview.Implementation.Commands;
using MovieReview.Application.Queries;
using MovieReview.Implementation.Queries;

namespace MovieReview.Api
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
            services.AddAutoMapper(typeof(EfAddMovie).Assembly);
            //services.AddAutoMapper(typeof(EfGetMoviesQuery).Assembly);
            services.AddTransient<MovieReviewContext>();
            services.AddTransient<UseCaseExecutor>();

            #region Validators
            services.AddTransient<AddUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<TokenValidator>();
            services.AddTransient<MovieValidator>();
            services.AddTransient<ReviewValidator>();
            #endregion

            #region User
            services.AddTransient<IAddUser, EfAddUser>();
            services.AddTransient<IUpdateUser, EfUpdateUser>();
            services.AddTransient<IDeleteUser, EfDeleteUser>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            #endregion

            #region Review
            services.AddTransient<IAddReview, EfAddReview>();
            services.AddTransient<IUpdateReview, EfUpdateReview>();
            services.AddTransient<IDeleteReview, EfDeleteReview>();
            services.AddTransient<IGetReviewsQuery, EfGetReviewsQuery>();
            services.AddTransient<IGetOneReviewQuery, EfGetOneReviewQuery>();
            #endregion

            #region Movie
            services.AddTransient<IAddMovie, EfAddMovie>();
            services.AddTransient<IUpdateMovie, EfUpdateMovie>();
            services.AddTransient<IDeleteMovie, EfDeleteMovie>();
            services.AddTransient<IGetOneMovieQuery, EfGetOneMovieQuery>();
            services.AddTransient<IGetMoviesQuery, EfGetMoviesQuery>();
            #endregion

            #region Actor
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                //izvuci token
                //pozicionirati se na payload
                //izvuci ActorData claim
                //Deserijalizovati actorData string u c# objekat

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    var anonymous = new JwtActor
                    {
                        Id = 5,
                        Identity = "Anonymouse Actor",
                        AllowedUseCases = new List<int> { 6,7,15,14,2,3 }

                    };

                    return anonymous;

                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            }); 
            #endregion
            
            #region JWT
            services.AddTransient<JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            }); 
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });
            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
