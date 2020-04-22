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

namespace APITEST
{
    public class Startup
    {
        /**
         * HTTP REQUEST GET ALL GROUPS => 
         * 1. STARTUP (Configure) PIPELINE
         * 2. SEARCH THE CONTROLLER => GROUP CONTROLLER
         * 3. CONTROLLER => Group Logic
         * 4. BUSINESS LOGIC => Retrieve Students from DB && Assign Groups
         * 5. DATABASE LAYER => manage students.
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            // Transient
            services.AddTransient<IGroupLogic, GroupLogic>();
            
            // SINGLETON 
            services.AddSingleton<IStudentTableDB, StudentTableDB>();

            // COPY THIS TO ENABLE SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    "v1", 
                    new Microsoft.OpenApi.Models.OpenApiInfo() 
                    { 
                        Title = "Group Selector API - DEV/QA", 
                        Version = "v1" 
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

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

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
