using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
namespace DAL.IDal
{
    public interface IGuanDal
    {
        //商品
        #region
        List<UnitModel> UnitBang();
        int GoodsAdd(GoodsModel model);
        List<GoodsModel> GooodsShow(int pagIndex, int pagSize, int typeId, string name, out int pagCount);
        int GoodsShan(string ids);
        GoodsModel GoodsFan(int id);
        int GoodsUpdate(GoodsModel model);
        List<TypeModel> TypeBanag();
        List<SuppleModel> SuppleBang();
        #endregion

        //设备
        #region
        int EquipmentAdd(EquipmentModel model);
        List<EquipmentModel> EquipmentShow(int pagIndex, int pagSize, string name, out int pagCount);
        int EquipmentShan(string ids);
        EquipmentModel EquipmentFan(int id);
        int EquipmentUpdate(EquipmentModel model);
        #endregion

        //报损
        #region
        int ReportAdd(ReportModel model);
        List<ReportModel> ReportShow(int pagIndex, int pagSize, out int pagCount);
        int ReportShan(string ids);
        ReportModel ReportFan(int id);
        int ReportUpdate(ReportModel model);
        #endregion

        //调库 LocationWith (库位详细表) Location (库位表)


        //退货 Returnd
        #region
        int ReturndAdd(ReturndModel model);
        List<ReturndModel> ReturndShow(int ReturnId, int ReturnGid, int ReturnPid, int RetrunNum, out int pagCount);
        int ReturndShan(string ids);
        ReturndModel ReturndFan(int id);
        int ReturndUpdate(ReturndModel model);
        #endregion
        //仓库 WareHouse


    }

}
