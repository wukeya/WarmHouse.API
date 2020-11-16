using DAL.IDal;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.WDal
{
    public class DenLuDal: IDengLuDal
    {
        public static IConfiguration _configuration;

        public DenLuDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化DBhelper
        DBHelper dBHelper = new DBHelper(_configuration);

        //用户 Userd 登录 注册/
        #region
        public UserdModel UserdDenLuint(string username, string userpass)
        {
            string sql = $"select count(1) from Userd where UserName='{username}'and UserPass='{userpass}'";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<UserdModel>(sql).ToList().FirstOrDefault();
            }
        }
        //注册 
        public int UserdZhuChe(UserdModel model)
        {
            string sql = $"insert into Userd values('{model.UserName}','{model.UserPass}') ";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        #endregion

    }
}
