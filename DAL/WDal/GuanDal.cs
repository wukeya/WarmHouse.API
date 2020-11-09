using DAL.IDal;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class GuanDal:IGuanDal
    {
        private IConfiguration _configuration;
        public GuanDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public  string conStr { get {return _configuration.GetConnectionString("a"); } set { } }
        //绑定单位
        public List<UnitModel> UnitBang()
        {
            string sql = "select  * from Units";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<UnitModel>(sql).ToList();
            }
        }
    }
}
