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
using Microsoft.AspNetCore.Http;

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
            .AddJsonFile("Env.json", optional: true)
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
             //   builder => builder.WithOrigins("http://otvcrm01:4507")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
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

            if (Configuration["environment"].ToString() == "Test")
            {

                services.AddDbContext<GcimsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GcimsContextDev")));

                services.AddDbContext<PortalContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PortalContextTest")));
              

            }
            else if (Configuration["environment"].ToString() == "Production")
            {
                services.AddDbContext<GcimsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("GcimsContext")));

                services.AddDbContext<PortalContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PortalContext")));
                
            }
            else if (Configuration["environment"].ToString() == "Development")
            {
                services.AddDbContext<GcimsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("GcimsContextDev")));

                services.AddDbContext<PortalContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PortalContextDev")));

            }
            else if (Configuration["environment"].ToString() == "Local")
            {
                services.AddDbContext<GcimsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("GcimsContextDev")));

                services.AddDbContext<PortalContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PortalContextLocal")));

            } 

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
            
            app.UseCors("CorsPolicy");
  
            app.UseMiddleware<AuthenticationMiddleware>();
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

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public static IConfigurationRoot Configuration { get; set; }
        public AuthenticationMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _next = next;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Env.json");

            Configuration = builder.Build();
        }

        public async Task Invoke(HttpContext context)
        {
            

            string authHeader = context.Request.Headers["Authorization"];
            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                //Extract credentials
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                int seperatorIndex = usernamePassword.IndexOf(':');

                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);
                
                if (username == Configuration["username"] && password == Configuration["password"])
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
        }
    }
}
