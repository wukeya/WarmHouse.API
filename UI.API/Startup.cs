using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.IBll;
using BLL.WBll;
using com.sun.tools.@internal.jxc.ap;
using DAL;
using DAL.IDal;
using DAL.WDal;
using Jose;
using LanguageExt.TypeClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            //时间格式配置
            services.AddControllers()
                .AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                });
            //注册
            services.AddTransient<IGuanDal,GuanDal>();
            services.AddTransient<IGuanBLL, GuanBll>();
            services.AddTransient<ICustomerDal,CustomerDal>();
            services.AddTransient<ICustomerBll,CustomerBll>();
            services.AddTransient<IDengLuDal, DenLuDal>();
            services.AddTransient<IDengLuBLL, DenLuBLL>();
            //跨域配置
            
            services.AddCors(options =>
           options.AddPolicy("cor",
           p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
           );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,  //是否验证超时  当设置exp和nbf时有效 
                       ValidateIssuerSigningKey = true,  ////是否验证密钥
                       ValidAudience = "http://localhost:49999",//Audience
                       ValidIssuer = "http://localhost:49998",//Issuer，这两项和登陆时颁发的一致
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456888jdijxhelloworldprefect")),     //拿到SecurityKey
                                                                                                                                   //缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟                                                                                                            //注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间，如果不配置，默认是5分钟
                       ClockSkew = TimeSpan.FromMinutes(5)   //设置过期时间
                   };
             });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //跨域
            app.UseCors("cor");
            app.UseRouting();
            //静态文件
            app.UseStaticFiles();
           
            app.UseAuthentication();   //认证
            app.UseAuthorization();    //授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
