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
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;

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

            var pathToDoc = Configuration["Swagger:FileName"];
            // Add CORS support
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddSwaggerGen(options =>
            {
                
                options.SwaggerDoc("v1",                     
                    new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Title = "API", 
                        Version = "v1", 
                        Description = "API for Portal System in AEM", 
                        TermsOfService = "None"
                    });
                options.DocumentFilter<TestFilter>();
                //var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
                //options.IncludeXmlComments(filePath);
                //options.DescribeAllEnumsAsStrings();
                
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
            app.UseCors("CorsPolicy");
            //app.UseCors(builder =>
            //  builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //);
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
           
            
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
                    
            app.UseMvc();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }

        
    } 
    public class TestFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Schemes = new string[] { "https", "http" };
            swaggerDoc.Consumes = new string[] { "application/json" };
            swaggerDoc.Produces = new string[] { "application/json" };

        }
    }
}
