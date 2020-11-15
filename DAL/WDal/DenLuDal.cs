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
        //注册 insert into Userd values('{model.UserName}','{model.UserPass}','{model.UserFId}') 
        public UserdModel UserdZhuChe(string username, string userpass)
        {
            string sql = $"select count(1) from Userd where UserName='{username}'and UserPass='{userpass}'";
            if (string.IsNullOrWhiteSpace(username))
            {
                sql += $"and insert int Userd values('{username}')";
            }
            else
            {
                Console.WriteLine("<script>alrer('请检查账号是否正确'),location.href('/Guan/GoodsShow');</script>");
            }
            if (string.IsNullOrWhiteSpace(userpass))
            {
                sql += $"and insert int Userd values('{userpass}')";
            }
            else
            {
                Console.WriteLine("<script>alrer('输入密码不正确'),location.href('/Guan/GoodsShow');</script>");
            }
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<UserdModel>(sql).ToList().FirstOrDefault();
            }
        }
        #endregion

    }
}
