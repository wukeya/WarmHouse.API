using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.IBll;
using BLL.WBll;
using DAL;
using DAL.IDal;
using DAL.WDal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UI.API
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
            //Ê±¼ä¸ñÊ½ÅäÖÃ
            services.AddControllers()
                .AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                });
            //×¢²á
            services.AddTransient<IGuanDal,GuanDal>();
            services.AddTransient<IGuanBLL, GuanBll>();
            services.AddTransient<ICustomerDal,CustomerDal>();
            services.AddTransient<ICustomerBll,CustomerBll>();
            
            //¿çÓòÅäÖÃ
            
            services.AddCors(options =>
           options.AddPolicy("cor",
           p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
           );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //¿çÓò
            app.UseCors("cor");
            app.UseRouting();
            //¾²Ì¬ÎÄ¼þ
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
