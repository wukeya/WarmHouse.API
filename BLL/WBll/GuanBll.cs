using BLL.IBll;
using DAL.IDal;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BLL
{
    public class GuanBll : IGuanBLL
    {
        //依赖注入
        private IGuanDal _idal;
        public GuanBll(IGuanDal dal)
        {
            _idal = dal;
        }
        //商品
        #region
        //添加商品
        public int GoodsAdd(GoodsModel model)
        {
            return _idal.GoodsAdd(model);
        }
        //删除商品
        public int GoodsShan(string ids)
        {
            return _idal.GoodsShan(ids);
        }
        //反填商品
        public GoodsModel GoodsFan(int id)
        {
            return _idal.GoodsFan(id);
        }
        //修改商品

        public int GoodsUpdate(GoodsModel model)
        {
            return _idal.GoodsUpdate(model);
        }
        //显示商品
        public List<GoodsModel> GooodsShow(int pagIndex, int pagSize, int typeId, string name, out int pagCount)
        {
            return _idal.GooodsShow(pagIndex, pagSize, typeId, name, out pagCount);
        }
        //绑定单位
        public List<UnitModel> UnitBang()
        {
            return _idal.UnitBang();
        }
        //绑定类型
        public List<TypeModel> TypeBanag()
        {
            return _idal.TypeBanag();
        }
        //绑定供应商
        public List<SuppleModel> SuppleBang()
        {
            return _idal.SuppleBang();
        }
        #endregion
        //设备
        #region
        //添加设备
        public int EquipmentAdd(EquipmentModel model)
        {
            return _idal.EquipmentAdd(model);
        }
        //显示设备
        public List<EquipmentModel> EquipmentShow(int pagIndex, int pagSize, string name, out int pagCount)
        {
            return _idal.EquipmentShow(pagIndex, pagSize, name, out pagCount);
        }
        //删除设备
        public int EquipmentShan(string ids)
        {
            return _idal.EquipmentShan(ids);
        }
        //反填设备
        public EquipmentModel EquipmentFan(int id)
        {
            return _idal.EquipmentFan(id);
        }
        //修改设备
        public int EquipmentUpdate(EquipmentModel model)
        {
            return _idal.EquipmentUpdate(model);
        }
        #endregion
        //报损
        #region
        //添加报损
        public int ReportAdd(ReportModel model)
        {
            return _idal.ReportAdd(model);
        }
        //显示报损
        public List<ReportModel> ReportShow(int pagIndex, int pagSize, out int pagCount)
        {
            return _idal.ReportShow(pagIndex, pagSize, out pagCount);
        }
        //删除报损
        public int ReportShan(string ids)
        {
            return _idal.ReportShan(ids);
        }
        //反弹报损
        public ReportModel ReportFan(int id)
        {
            return _idal.ReportFan(id);
        }
        //修改报损
        public int ReportUpdate(ReportModel model)
        {
            return _idal.ReportUpdate(model);
        }
        #endregion
        //退货
        #region
        //添加退货信息
        public int ReturndAdd(ReturndModel model)
        {
            return _idal.ReturndAdd(model);
        }
        //显示退货
        public List<ReturndModel> ReturndShow(int ReturnId, int ReturnGid, int ReturnPid, int RetrunNum, out int pagCount)
        {
            return _idal.ReturndShow(ReturnId, ReturnGid, ReturnPid, RetrunNum,out pagCount);
        }
        //删除退货
        public int ReturndShan(string ids)
        {
            return _idal.ReportShan(ids);
        }
        //退货反填Returnd
        public ReturndModel ReturndFan(int id)
        {
            return _idal.ReturndFan(id);
        }
        //修改退货
        public int ReturndUpdate(ReturndModel model)
        {
            return _idal.ReturndUpdate(model);
        }
        #endregion
    }
}
