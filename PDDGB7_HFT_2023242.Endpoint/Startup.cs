using LibGit2Sharp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PDDGB7_HFT_2023242.Logic.Classes;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Data;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using PDDGB7_HFT_2023242.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Endpoint
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
            services.AddTransient<GamesDbContext>();

            services.AddTransient<IRepository<Developer>, DeveloperRepository>();
            services.AddTransient<IRepository<Game>, GameRepository>();
            services.AddTransient<IRepository<RentLog>, RentLogRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            services.AddTransient<IDeveloperLogic, DeveloperLogic>();
            services.AddTransient<IGameLogic, GameLogic>();
            services.AddTransient<IRentLogLogic, RentLogLogic>();
            services.AddTransient<IUserLogic, UserLogic>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PDDGB7_HFT_2023242.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDDGB7_HFT_2023242.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
