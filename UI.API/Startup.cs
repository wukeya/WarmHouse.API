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
            //ʱ���ʽ����
            services.AddControllers()
                .AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                });
            //ע��
            services.AddTransient<IGuanDal,GuanDal>();
            services.AddTransient<IGuanBLL, GuanBll>();
            services.AddTransient<ICustomerDal,CustomerDal>();
            services.AddTransient<ICustomerBll,CustomerBll>();
            services.AddTransient<IDengLuDal, DenLuDal>();
            services.AddTransient<IDengLuBLL, DenLuBLL>();
            //��������
            
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
                     ValidateLifetime = true,  //�Ƿ���֤��ʱ  ������exp��nbfʱ��Ч 
                       ValidateIssuerSigningKey = true,  ////�Ƿ���֤��Կ
                       ValidAudience = "http://localhost:49999",//Audience
                       ValidIssuer = "http://localhost:49998",//Issuer��������͵�½ʱ�䷢��һ��
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456888jdijxhelloworldprefect")),     //�õ�SecurityKey
                                                                                                                                   //�������ʱ�䣬�ܵ���Чʱ��������ʱ�����jwt�Ĺ���ʱ�䣬��������ã�Ĭ����5����                                                                                                            //ע�����ǻ������ʱ�䣬�ܵ���Чʱ��������ʱ�����jwt�Ĺ���ʱ�䣬��������ã�Ĭ����5����
                       ClockSkew = TimeSpan.FromMinutes(5)   //���ù���ʱ��
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
            //����
            app.UseCors("cor");
            app.UseRouting();
            //��̬�ļ�
            app.UseStaticFiles();
           
            app.UseAuthentication();   //��֤
            app.UseAuthorization();    //��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
