using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using DAL.IDal;

namespace DAL.WDal
{
    public  class CustomerDal:ICustomerDal
    {
        public static IConfiguration _configuration;

        public CustomerDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public string conStr { get { return _configuration.GetConnectionString("a"); } set { } }
        //添加选购清单
        public int SelectOrderAdd(SelectOrderModel model) 
        {
            string sql = $"insert into SelectOrder values('{model.SelectOrderCode}','{model.SelectOrderTime}','{model.SelectOrderPeople}','{model.SelectOrderState}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //添加选购详细
        public int SelectOrderDeitAdd(SelectOrderDeitModel model) 
        {
            string sql = $"insert into SelectOrderDeit values('{model.SelectOrderDeitGid}','{model.SelectOrderDeitCode}','{model.SelectOrderDeitNum}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示购物清单
        public List<SelectOrderModel> SelectOrderShow() 
        {
            string sql = $"select  * from SelectOrder";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<SelectOrderModel>(sql).ToList();
            }
        }
        //通过id查找code
        public string SelectOrderSerachCode(int id)
        {
            string sql = $"select  SelectOrderCode from SelectOrder where SelectOrderId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.ExecuteScalar(sql).ToString();
            }
        }
        //显示购物清单详细
        public List<SelectOrderDeitModel> SelectOrderDeitShow(string code)
        {
            string sql = $"select * from SelectOrderDeit s join Goods g on g.GoodsId=s.SelectOrderDeitGid  where SelectOrderDeitCode ='{code}'";

            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<SelectOrderDeitModel>(sql).ToList();
            }
        }
        
    }
}
