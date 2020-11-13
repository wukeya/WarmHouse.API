using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
namespace DAL.IDal
{
    public interface IGuanDal
    {

        //用户 Userd 登录 注册 
        #region
        UserdModel UserdDenLuint(string username, string userpass);
        int UserdZhuChe(UserdModel model);
        #endregion

        //商品
        List<UnitModel> UnitBang();
        int GoodsAdd(GoodsModel model);
        List<GoodsModel> GooodsShow(int pagIndex, int pagSize, int typeId, string name, out int pagCount);
        int GoodsShan(string ids);
        GoodsModel GoodsFan(int id);
        int GoodsUpdate(GoodsModel model);
        List<TypeModel> TypeBanag();
        List<SuppleModel> SuppleBang();
        int GoodsUpdateState(int state, int id);
        //设备
        int EquipmentAdd(EquipmentModel model);
        List<EquipmentModel> EquipmentShow(int pagIndex, int pagSize, string name, out int pagCount);
        int EquipmentShan(string ids);
        EquipmentModel EquipmentFan(int id);
        int EquipmentUpdate(EquipmentModel model);
        //报损
        int ReportAdd(ReportModel model);
        List<ReportModel> ReportShow(int pagIndex, int pagSize, out int pagCount);
        int ReportShan(string ids);
        ReportModel ReportFan(int id);
        int ReportUpdate(ReportModel model);
        //添加采购订单表
        int PurchaseAdd(PurchaseModel model);
        //添加订单详情表
        bool OrderDeits(int pid, string ids, string nums);
        //显示采购订单表
        List<PurchaseModel> PurchaseShow();
        //查看采购订单详情
        List<OrderDeitModel> OrderDeitShow(int pid);
        //修改采购订单详情State
        int OrderUpdateState(int state, int oid);
        //显示仓库
        List<WareHouseModel> WareHouseShow();
        //添加库位
        int LocationAdd(LocationModel model);
        //显示库位
        List<LocationModel> LocationShow(int wid);
        //添加库位详
        int LocationWithAdd(LocationWithModel model);
       
        //添加入库清单
        int RuChecklistAdd(RuchecklistModel model);
        //添加库位详情临时
        public int TempLocationWithAdd(LocationWithModel model);
        //查看临时库位详情表
        List<TempLocationWithModel> TempLocationWithShow();
        //清空临时表
        int TempLocationWithDelete();
        //查看入库清单表
        List<RuchecklistModel> RuchecklistShow();
        //通过ID找Code
        string SearchCode(int id);
        //显示库位详细
        List<LocationWithModel> LocationWithShow(string code);
        //判断是否入库
        int IsRuKu(int oid);
        //退货
        int ReturndAdd(ReturndModel model);
        List<ReturndModel> ReturndShow();
        int ReturndShan(string ids);
        


    }
}
