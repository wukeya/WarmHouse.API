using DAL.IDal;
using Dapper;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace DAL.WDal
{
    public class DenLuDal: IDengLuDal
    {

        public static IConfiguration _configuration;
        public string connstr;
        public DenLuDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //实例化jwt
        JWTHelper helper = new JWTHelper();

        //用户密码解密
        #region
        public string SearchPass(string username)
        {         
            string sql = $"select * from Userd where UserName='{username}'";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
               
                UserdModel model= connection.Query<UserdModel>(sql).ToList().FirstOrDefault();
                //解密密码
                string code = helper.GetPayload(model.UserPass);
                JwtModel jwt = JsonConvert.DeserializeObject<JwtModel>(code);
                string str = jwt.userpass;
                return str;
            }
        }
       
        //用户登录
        public UserdModel UserLogin(string name,string pass) 
        {       
            string sqlstr = $"select UserPass from Userd where UserName='{name}'";      
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                 connstr = connection.ExecuteScalar(sqlstr).ToString();
            }
            string sql = $"select * from Userd where UserName='{name}'and UserPass='{connstr}'";
            using (SqlConnection connection1=new SqlConnection(conStr))
            {
                return connection1.Query<UserdModel>(sql).ToList().FirstOrDefault();
            }
        }
        //注册 insert into Userd values('{model.UserName}','{model.UserPass}','{model.UserFId}') 
        public int UserdZhuChe(UserdModel model)
        {
            //密码加密
            //定义一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("userpass", model.UserPass);
            //调用加密方法
            var str = helper.GetToken(pairs, 10000);
            string sql = $"insert into Userd values('{model.UserName}','{str}','{model.UserFId}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }

        }
        #endregion

    }
}
