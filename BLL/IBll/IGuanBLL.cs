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
    }
}
