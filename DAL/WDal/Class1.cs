using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace DAL
{
    public class Class1
    {
        private IConfiguration _configuration;
        public Class1(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public  string Constraint { get {return _configuration.GetConnectionString("a"); } set { } }
    }
}
