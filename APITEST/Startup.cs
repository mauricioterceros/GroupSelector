using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using APITEST.BusinessLogic;
using APITEST.Database;
using Services;
using Serilog;
using Serilog.Events;
using APITEST.Middlewares;

namespace APITEST
{
    public class Startup
    {
        const string SWAGGER_SECTION_SETTING_KEY = "SwaggerSettings";
        const string SWAGGER_SECTION_SETTING_TITLE_KEY = "Title";
        const string SWAGGER_SECTION_SETTING_VERSION_KEY = "Version";
        /**
         * HTTP REQUEST GET ALL GROUPS => 
         * 1. STARTUP (Configure) PIPELINE
         * 2. SEARCH THE CONTROLLER => GROUP CONTROLLER
         * 3. CONTROLLER => Group Logic
         * 4. BUSINESS LOGIC => Retrieve Students from DB && Assign Groups
         * 5. DATABASE LAYER => manage students.
         */
        public Startup(IWebHostEnvironment env)
        {
            // "appsettings." + env.EnvironmentName + ".json"
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            string logpath = Configuration.GetSection("Logging").GetSection("FileLocation").Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .WriteTo.Console()
                .WriteTo.RollingFile(logpath, LogEventLevel.Information)
                .CreateLogger();

            Log.Information("This app is using the config file: " + $"appsettings.{env.EnvironmentName}.json");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // Business Logic
            services.AddTransient<IGroupStudentLogic, GroupStudentLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<IGroupLogic, GroupLogic>();
            // Database Layer
            services.AddTransient<IGroupDBManager, GroupDBManager>();
            services.AddTransient<IStudentDBManager, StudentDBManager>();
            services.AddTransient<IGroupStudentDBManager, GroupStudentDBManager>();            

            services.AddTransient<IProductBackingService, ProductBackingService>();

            // Services Injector Container
            // Transient => lifetime will be ONLY in the scope that is been executed
            // Scoped => lifetime will be GLOBAL in the HTTP REQUEST
            // Singleton => lifetime will be from Program starts until ends. ==> MemoryLeaks

            // ADDING CORS
            // 1. Update launch settings according with config
            // 2. Add this block to startup (ConfigureServices)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      );
            });
            // End CORS block

            var swaggerTitle = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_TITLE_KEY);
            var swaggerVersion = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_VERSION_KEY);

            // COPY THIS TO ENABLE SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    swaggerVersion.Value, 
                    new Microsoft.OpenApi.Models.OpenApiInfo() 
                    { 
                        Title = swaggerTitle.Value, 
                        Version = swaggerVersion.Value
                    }
                );
            });
        }

        // PIPELINE
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHanlderMiddleware();

            // app.UseHsts();
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorizationMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // COPY THIS TO ENABLE SWAGGER
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Group Selector");
            });
        }
    }
}
