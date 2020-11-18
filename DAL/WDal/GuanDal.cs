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

        //商品
        #region
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
        //反填商品d
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
        #endregion
        //设备
        #region
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
        #endregion
        //报损
        #region
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
        //反填报损
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

        //添加采购订单表
        public int PurchaseAdd(PurchaseModel model) 
        {
            model.PurchaseState = 0;
            model.PurchaseTime = DateTime.Now;
            string sql = @$"insert into Purchase values('{model.PurchaseUid}','{model.PurchasePid}','{model.PurchaseCode}','{model.PurchaseTime}','{model.PurchaseState}');
                           select @@IDENTITY";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return Convert.ToInt32(connection.ExecuteScalar(sql));
            }
        }
        //添加采购表和详细
        public bool OrderDeits(int pid,string ids,string nums) 
        {
            List<string> list = new List<string>();
            //把ids分割为数值
            var arr = ids.Split(',');
            var arr2= nums.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                string sql = $"insert into OrderDeit values('{pid}','{arr[i]}','{arr2[i]}',0)";
                list.Add(sql);
            } 
            return dBHelper.ExecuteSqlTran(list);
        }
        //显示采购订单表
        public List<PurchaseModel> PurchaseShow() 
        {
            string sql = $"select * from Purchase";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<PurchaseModel>(sql).ToList();
            }
        }
        //查看采购订单详情
        public List<OrderDeitModel> OrderDeitShow(int pid)
        {
            string sql = $"select * from  Goods g join OrderDeit d on g.GoodsId=d.OGid join Purchase p on p.PurchaseId=d.OPid join Units u on u.UnitId=g.GoodsUid join Typed  t on t.TypedId=g.GoodsTid    where  d.OPid={pid}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<OrderDeitModel>(sql).ToList();
            }
        }
        //修改采购订单详情State
        public int OrderUpdateState(int state, int oid) 
        {
            string sql = $"update OrderDeit set OState={state}  where OrderId={oid} ";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }

        #endregion
        //退货
        #region
        //添加退货信息
        public int ReturndAdd(ReturndModel model)
        {
            string sql = $"insert into Returnd values('{model.ReturnOid}','{model.ReturnPid}','{model.ReturnState}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示退货
        public List<ReturndModel> ReturndShow() 
        {
            string sql = $"select * from Returnd  r join Purchase p on p.PurchaseId=r.ReturnPid join  OrderDeit o on o.OrderId=r.ReturnOid join Goods g on g.GoodsId=o.OGid ";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                List<ReturndModel> list = connection.Query<ReturndModel>(sql).ToList();
                return list;
            }
        }
        //删除退货
        public int ReturndShan(string ids)
        {
            string sql = $"delete from Returnd where ReturnId like ({ids})";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
     
        #endregion
        //库位
        #region
        //添加库位
        public int LocationAdd(LocationModel model) 
        {
            string sql = $"insert into Location values('{model.LocationWid}','{model.LocationName}','{model.LocationMin}','{model.LocationMax}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示库位
       public  List<LocationModel> LocationShow(int wid)
        {
            string sql = $"select  * from Location where LocationWid={wid}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<LocationModel>(sql).ToList();
            }
        }
        //添加库位详
        public int LocationWithAdd(LocationWithModel model) 
        {
            string sql = $"insert into LocationWith values('{model.LocationRuCode}','{model.LocationWid}','{model.LocationLid}','{model.LocationWithOid}','{model.LocationState}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //添加入库清单表
        public int RuChecklistAdd(RuchecklistModel model) 
        {
            string sql = $"insert into Ruchecklist values('{model.RuchecklistCode}','{model.RuchecklistTime}','{model.RuchecklistPeople}',{model.RucheckState});";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //添加临时库位详
        public int TempLocationWithAdd(LocationWithModel model)
        {
            string sql = $"insert into TempLocationWith values('{model.LocationWid}','{model.LocationLid}','{model.LocationWithOid}','{model.LocationState}')";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //查看临时库位详情
        public List<TempLocationWithModel> TempLocationWithShow() 
        {
            string sql = $"select * from TempLocationWith";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<TempLocationWithModel>(sql).ToList();
            }
        }
        //清空临时库位详情
        public int TempLocationWithDelete() 
        {
            string sql = $"delete from TempLocationWith";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //查看入库清单
        public List<RuchecklistModel> RuchecklistShow() 
        {
            string sql = "select *from  Ruchecklist";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<RuchecklistModel>(sql).ToList();

            }
        }
        //通过Id查看编号
        public string SearchCode(int id)
        {
            string sql = $"select RuchecklistCode from  Ruchecklist where RuchecklistId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.ExecuteScalar(sql).ToString();
            }

        }
        //查看入库清单详细
        public List<LocationWithModel> LocationWithShow(string code) 
        {
            string sql = $"select * from LocationWith l join OrderDeit o on o.OrderId=l.LocationWithOid join Goods g on g.GoodsId=o.OGid join WareHouse w on w.WareHouseId=l.LocationWid join Location on l.LocationLid=LocationId join Ruchecklist r on r.RuchecklistCode=l.LocationRuCode where LocationRuCode='{code}'";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                List<LocationWithModel> list = connection.Query<LocationWithModel>(sql).ToList();
                return list;
            }
        }
        //查找出库前商品
        public List<LocationWithModel> BeforeChuKu(int id)
        {
            string sql = $"select * from LocationWith l join OrderDeit o on o.OrderId=l.LocationWithOid join Goods g on g.GoodsId=o.OGid join WareHouse w on w.WareHouseId=l.LocationWid join Location on l.LocationLid=LocationId join Ruchecklist r on r.RuchecklistCode=l.LocationRuCode where g.GoodsId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                List<LocationWithModel> list = connection.Query<LocationWithModel>(sql).ToList();
                return list;
            }
        }
        //出库过程
        public int HavingChuKu(int num, int sid, int lid)
        {
            //定义一个集合
            List<string> list = new List<string>();
            string sql = $"update OrderView set ONum=ONum-{num} where LocationWithId={lid}";
            //把sql语句加入list
            list.Add(sql);
            sql = $"update SelectOrderDeit set SelectOrderDeitNum=SelectOrderDeitNum-{num} where SelectOrderDeitId={sid}";
            list.Add(sql);
            //执行事务
            bool b = dBHelper.ExecuteSqlTran(list);
            if (b==true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //添加出库清单
        public int RetrievealAdd(RetrievealModel model)
        {
            string sql = $"insert into Retrieveal values('{model.RetrievealCode}','{model.RetrievealUid}','{model.RetrievealTime}','{model.RetrievealState}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示出库清单表
        public List<RetrievealModel> RetrievealShow()
        {
            string sql = $"select * from Retrieveal";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<RetrievealModel>(sql).ToList();
            }
        }
        //添加出库清单详细表
        public int RetrievealDeitAdd(RetrievealDeitModel model)
        {
            string sql = $"insert into RetrievealDeit values('{model.RetrievealDeitCode}','{model.RetrievealDeitLid}','{model.RetrievealDeitNum}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //通过Id查找Code
        public string RetrievealSearchCode(int id)
        {
            string sql = $"select RetrievealCode  from Retrieveal where RetrievealId={id}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.ExecuteScalar(sql).ToString();
            }
        }
        //查看出库清单详情
        public List<RetrievealDeitModel> RetrievealDeitShow(string code)
        {
            string sql = $"select* from RetrievealDeit where RetrievealDeitCode='{code}'";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<RetrievealDeitModel>(sql).ToList();
            }
        }
        //添加出库清单详细临时表
        public int TempRetrievealDeitAdd(TempRetrievealDeitModel model)
        {
            string sql = $"insert into TempRetrievealDeit values('{model.TempRetrievealDeitLid}','{model.TempRetrievealDeitNum}')";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示出库清单详细临时表
        public List<TempRetrievealDeitModel> TempRetrievealDeitShow() 
        {
            string sql = $"select *from TempRetrievealDeit";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<TempRetrievealDeitModel>(sql).ToList();
            }
        }
        //清空出库清单详细临时
        public int DeleteTempRetrievealDeit()
        {
            string sql = $"delete from TempRetrievealDeit";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        }
        //显示仓库
        public List<WareHouseModel> WareHouseShow()
        {
            string sql = $"select * from WareHouse";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return connection.Query<WareHouseModel>(sql).ToList();
            }
        }
     
        //判断是否入库
        public int IsRuKu(int oid=0)
        {
            string sql = $"select count(1) from LocationWith where LocationWithOid={oid}";
            using (SqlConnection connection=new SqlConnection(conStr))
            {
                return Convert.ToInt32(connection.ExecuteScalar(sql));
            }
        }
        #endregion
        //调库 
        #region
        public int LocationWithUpdate(LocationWithModel model)
        {
            string sql = $"update UpdateLocation set LocationWid='{model.LocationWid}',LocationLid='{model.LocationLid}' where LocationWithId='{model.LocationWithId}'";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                return connection.Execute(sql);
            }
        } 
        //显示调库信息
        public List<LocationWithModel> UpdateLocationShow(int pagIndex, int pagSize, string name, out int pagCount)
        {
            string sql = "UpdateLocationPag";
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
            List<LocationWithModel> list = dBHelper.DataTableToList<LocationWithModel>(table);
            return list;
        }
        #endregion
    }
}

