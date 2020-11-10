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
        
        public static IConfiguration _configuration;
        public GuanDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //连接数据库
        public  string conStr { get {return _configuration.GetConnectionString("a"); } set { } }
        //实例化DBhelper
        DBHelper dBHelper = new DBHelper(_configuration);
        //添加商品
        public int GoodsAdd(GoodsModel model)
        {
            string sql = $"insert into Goods values('{model.GoodsName}','{model.GoodsTid}','{model.GoodsSid}','{model.GoodsImg}','{model.GoodsCode}','{model.GoodsUid}','{model.GoodsNum}','{model.GoodsMoney}','{model.GoodsSize}','{model.GoodsPeople}','{model.GoodsState}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //删除商品
        public int GoodsShan(string ids)
        {
            string sql = $"delete from Goods where GoodsId in ({ids})";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        
        //反填商品
        public GoodsModel GoodsFan(int id)
        {
            string sql = $"select  * from Goods g join Units u on g.GoodsUid=u.UnitId  join Typed t on g.GoodsTid=t.TypedId join Supple s on s.SuppleId=g.GoodsSid where GoodsId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<GoodsModel>(sql).ToList().FirstOrDefault();
            }
        }

       //修改商品

        public int GoodsUpdate(GoodsModel model)
        {
            string sql = $"update Goods set GoodsName='{model.GoodsName}',GoodsTid='{model.GoodsTid}',GoodsSid='{model.GoodsSid}',GoodsImg='{model.GoodsImg}',GoodsCode='{model.GoodsCode}',GoodsUid='{model.GoodsUid}',GoodsNum='{model.GoodsNum}',GoodsMoney='{model.GoodsMoney}',GoodsSize='{model.GoodsSid}',GoodsPeople='{model.GoodsPeople}',GoodsState='{model.GoodsState}' where GoodsId={model.GoodsId}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        //显示商品
        public List<GoodsModel> GooodsShow(int pagIndex,int pagSize,int typeId,string name,out int pagCount)
        {
            //sql语句
            string sql = "GoodPag";
            //给输出参数赋值
            pagCount = 0;
            //定义一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            //加入字典
            pairs.Add("@pagIndex", pagIndex);
            pairs.Add("@pagCount",pagCount);
            pairs.Add("@pagSize", pagSize);
            pairs.Add("@name", name);
            pairs.Add("@typeid", typeId);
            DataTable tb = dBHelper.GetProc(sql, pairs,out pagCount);
            //把DataTable转化为List
            List<GoodsModel> list = dBHelper.DataTableToList<GoodsModel>(tb);
            return list;
        }
        //修改商品状态
        public int GoodsUpdateState(int state, int id) 
        {
            string sql = $"update Goods set GoodsState={state} where GoodsId={id}";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        //绑定单位
        public List<UnitModel> UnitBang()
        {
            string sql = "select  * from Units";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<UnitModel>(sql).ToList();
            }
        }
        //绑定类型
        public List<TypeModel> TypeBanag() 
        {
            string sql = $"select  * from Typed";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<TypeModel>(sql).ToList();         
            }
        }
        //绑定供应商
        public List<SuppleModel> SuppleBang() 
        {
            string sql = $"select* from  Supple";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<SuppleModel>(sql).ToList();
            }
        }
        //添加设备
        public int EquipmentAdd(EquipmentModel model) 
        {
            string sql = $"insert into Equipment values('{model.EquipmentName}','{model.EquipmentMoney}','{model.EquipmentState}','{model.EquipmentNum}','{model.EquipmentPeople}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示设备
        public List<EquipmentModel> EquipmentShow(int pagIndex, int pagSize, string name, out int pagCount) 
        {
            string sql = "EquipmentPag";
            //给输出参数赋值
            pagCount = 0;
            //实例化一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@pagIndex", pagIndex);
            pairs.Add("@pagSize", pagSize);
            pairs.Add("@name", name);
            pairs.Add("@pagCount", pagCount);
            //调用储存过程
            DataTable table = dBHelper.GetProc(sql, pairs, out pagCount);
            //把DataTable转化为List
            List<EquipmentModel> list = dBHelper.DataTableToList<EquipmentModel>(table);
            return list;
        }
        //删除设备
        public int EquipmentShan(string ids) 
        {
            string sql = $"delete from Equipment where EquipmentId in ({ids})";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //反填设备
        public EquipmentModel EquipmentFan(int id) 
        {
            string sql = $"select * from Equipment where EquipmentId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<EquipmentModel>(sql).ToList().FirstOrDefault();
            }
        }
        //修改设备
        public int EquipmentUpdate(EquipmentModel model) 
        {
            string sql = $"update Equipment set EquipmentName='{model.EquipmentName}',EquipmentMoney='',EquipmentState='{model.EquipmentState}',EquipmentNum='{model.EquipmentNum}',EquipmentPeople='{model.EquipmentPeople}' where EquipmentId={model.EquipmentId}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //添加报损
        public int ReportAdd(ReportModel model) 
        {
            string sql = $"insert into Reported values('{model.ReportedTime}','{model.ReportedGid}','{model.ReportedNum}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示报损
        public List<ReportModel> ReportShow(int pagIndex, int pagSize, out int pagCount) 
        {
            pagCount = 0;
            string sql = "ReportPag";
            //实例化一个字典
            Dictionary<string, object> pairs = new Dictionary<string, object>();
            pairs.Add("@pagIndex", pagIndex);
            pairs.Add("@pagSize", pagSize);
            pairs.Add("@pagCount", pagCount);
            //调用储存过程
            DataTable tb = dBHelper.GetProc(sql, pairs, out pagCount);
            //吧DataTable转化为list
            List<ReportModel> list = dBHelper.DataTableToList<ReportModel>(tb);
            return list;

        }
        //删除报损
        public int ReportShan(string ids) 
        {
            string sql = $"delete from Reported where ReportedId in ({ids})";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //反弹报损
        public ReportModel ReportFan(int id) 
        {
            string sql = $"select * from Reported where ReportedId={id}";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Query<ReportModel>(sql).ToList().FirstOrDefault();
            }
        }
        //修改报损
        public int ReportUpdate(ReportModel model) 
        {
            string sql = $"update Reported set ReportedTime='{model.ReportedTime}',ReportedGid='{model.ReportedGid}',ReportedNum='{model.ReportedNum}' where ReportedId='{model.ReportedId}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
    }
}
