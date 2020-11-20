using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IBll
{
    public interface IGuanBLL
    {
      

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
        int EquipmentStateUpdate(int state, int id);
        //报损
        int ReportAdd(ReportModel model);
        List<ReportModel> ReportShow(int pagIndex, int pagSize);
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
        //添加入库清单
        int RuChecklistAdd(RuchecklistModel model);
        //添加库位详情临时
        public int TempLocationWithAdd(LocationWithModel model);
        //修改采购订单详情State
        int OrderUpdateState(int state, int oid);
        //显示仓库
        List<WareHouseModel> WareHouseShow();
        //显示仓库详细
        List<LocationWithModel> WareHouseDeitShow(int id);
        //添加仓库
        int WarmHouseAdd(WareHouseModel model);
        //添加库位
        int LocationAdd(LocationModel model);
        //添加临时库位
        int TemLocationAdd(LocationModel model);
        //显示临时库位
        List<LocationModel> TemLocationShow();
        //清空临时库位
        int TemLocationDelete();
        //显示库位
        List<LocationModel> LocationShow(int wid);
        //添加库位详
        int LocationWithAdd(LocationWithModel model);
        //显示全部库位详情
        List<LocationWithModel> AllLocationWithShow();
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
        //出库前查找商品
        List<LocationWithModel> BeforeChuKu(int id);
        //出库过程
        int HavingChuKu(int num, int sid, int lid);
        //添加出库清单
        int RetrievealAdd(RetrievealModel model);
        //显示出库清单
        List<RetrievealModel> RetrievealShow();
        //添加出库清单详情
        int RetrievealDeitAdd(RetrievealDeitModel model);
        //查找编号
        string RetrievealSearchCode(int id);
        //显示出库清单详情
        List<RetrievealDeitModel> RetrievealDeitShow(string code);
        //添加出库清单详细临时
        int TempRetrievealDeitAdd(TempRetrievealDeitModel model);
        //显示出库清单详细临时
        List<TempRetrievealDeitModel> TempRetrievealDeitShow();
        //清空出库清单临时
        int DeleteTempRetrievealDeit();
        //退货
        int ReturndAdd(ReturndModel model);
        List<ReturndModel> ReturndShow();
        int ReturndShan(string ids);
        int GoodsNumReduce(int lid, int num);


    }
}
