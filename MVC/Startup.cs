 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.EfStructure;
using AutoMapper;
using Service.Methods;
using MVC.Models;
using Ninject.Modules;
using System.Reflection;
using Ninject;
using Autofac;
using MVC.Dependency;

namespace MVC
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

            // PREBACI SE NA NINJECT
            //services.AddScoped<IVehicleMakeService, VehicleMakeService>();
            //services.AddScoped<IVehicleModelService, VehicleModelService>();

            services.AddOptions();

            services.AddControllersWithViews();
            services.AddDbContext<VehicleContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("VehicleConnection")));

            //services.AddAutoMapper(typeof(VehicleModelProfile));

            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new VehicleModelProfile());
                c.AddProfile(new VehicleMakeProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyRegister());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    
}
