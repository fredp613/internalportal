using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InternalPortal
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
          
                //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS support
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            // Add framework services.
            services.AddMvc()
                   .AddJsonOptions(options => {
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   });
            
            services.AddDbContext<GcimsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GcimsContext")));

           // services.AddDbContext<PortalContext>(options =>
             //       options.UseSqlServer(Configuration.GetConnectionString("PortalContext")));

            services.AddDbContext<PortalContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PortalContext2")));


            //	    services.AddDbContext<PortalContext>(options =>
            //				options.UseNpgsql(Configuration.GetConnectionString("PortalContextPsql")));

            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy(
            //         "InternalUser",
            //         policy => policy.Requirements.Add(new InternalUserRequirement()));
            // });
            // services.AddSingleton<IAuthorizationHandler, InternalUserHandler>();
            //  services.Configure<IISOptions>(options => options.ForwardWindowsAuthentication = true);
            //  services.AddMvc();
            
            //services.Configure<IISOptions>(options => options.AutomaticAuthentication = true);


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
	      //  app.UseJwtBearerAuthentication(new JwtBearerOptions
	      //  {
	      //      AutomaticAuthenticate = true,
	      //      AutomaticChallenge = true,
	      //      TokenValidationParameters = new TokenValidationParameters
	      //      {
		  //          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppConfiguration:Key").Value)),
		  //          ValidAudience = Configuration.GetSection("AppConfiguration:SiteUrl").Value,
		  //          ValidateIssuerSigningKey = true,
		  //          ValidateLifetime = true,
		  //          ValidIssuer = Configuration.GetSection("AppConfiguration:SiteUrl").Value
	      //          }
	      //  });
            app.UseCors("CorsPolicy");            
            app.UseMvc();
        }

        
    }
}
