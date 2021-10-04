////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Builder;
////using Microsoft.AspNetCore.Hosting;
////using Microsoft.AspNetCore.HttpsPolicy;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.Extensions.Configuration;
////using Microsoft.Extensions.DependencyInjection;
////using Microsoft.Extensions.Hosting;
////using Microsoft.Extensions.Logging;
////using Microsoft.OpenApi.Models;

////namespace FlowApi
////{
////    public class Startup
////    {
////        public Startup(IConfiguration configuration)
////        {
////            Configuration = configuration;
////        }

////        public IConfiguration Configuration { get; }

////        // This method gets called by the runtime. Use this method to add services to the container.
////        public void ConfigureServices(IServiceCollection services)
////        {

////            services.AddControllers();
////            services.AddSwaggerGen(c =>
////            {
////                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlowApi", Version = "v1" });
////            });
////        }

////        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
////        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
////        {
////            if (env.IsDevelopment())
////            {
////                app.UseDeveloperExceptionPage();
////                app.UseSwagger();
////                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlowApi v1"));
////            }

////            app.UseHttpsRedirection();
////            loggerFactory.AddLog4Net();

////            app.UseRouting();

////            app.UseAuthorization();

////            app.UseEndpoints(endpoints =>
////            {
////                endpoints.MapControllers();
////            });
////        }
////    }


////}


using FlowApi.FlowerModel;
using FlowApi.Provider;
using FlowApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowApi
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
            services.AddDbContext<dbFlowerStoreContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           services.AddScoped<IFlower, RepoClass>();
           services.AddScoped<Iprovider, Providerclass>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FlowApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlowApi v1"));
            }
            loggerFactory.AddLog4Net();
            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors(options => options.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
