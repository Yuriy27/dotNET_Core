using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSA_netCore.Logger;
using BSA_netCore.Models.EF;
using BSA_netCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BSA_netCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=.\SQLEXPRESS;Database=coreDB;Trusted_Connection=True;";
            services.AddDbContext<GameContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<MatchesService, MatchesService>();
            
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, GameContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            
            //Custom logs
            loggerFactory.AddFileLogger(c =>
            {
                c.LogLevel = LogLevel.Information;
                c.FilePath = "info_logs.log";
            });
            loggerFactory.AddFileLogger(c =>
            {
                c.LogLevel = LogLevel.Error;
                c.FilePath = "error_logs.log";
            });

            app.UseMvc();

            DbInitializer.Initialize(context);
        }
    }
}
