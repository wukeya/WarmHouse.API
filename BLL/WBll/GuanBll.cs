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
        //修改商品状态
        public int GoodsUpdateState(int state, int id) 
        {
            return _idal.GoodsUpdateState(state, id);
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

        //采购
        #region

        //添加采购订单表
        public int PurchaseAdd(PurchaseModel model)
        {
            return _idal.PurchaseAdd(model);
        }
        //添加采购表和详细
        public bool OrderDeits(int pid, string ids, string nums)
        {
            return _idal.OrderDeits(pid, ids, nums);
        }
        //显示采购订单表
        public List<PurchaseModel> PurchaseShow()
        {
            return _idal.PurchaseShow();
        }
        //查看采购订单详情
        public List<OrderDeitModel> OrderDeitShow(int pid)
        {
            return _idal.OrderDeitShow(pid);
        }
        //修改采购订单详情State
        public int OrderUpdateState(int state, int oid)
        {
            return _idal.OrderUpdateState(state, oid);
        }
        #endregion

        //库位
        #region

        //添加库位
        public int LocationAdd(LocationModel model)
        {
            return _idal.LocationAdd(model);
        }
        //显示库位
        public List<LocationModel> LocationShow(int wid)
        {
            return _idal.LocationShow(wid);
        }
        //添加库位详
        public int LocationWithAdd(LocationWithModel model)
        {
            return _idal.LocationWithAdd(model);
        }
        //显示仓库
        public List<WareHouseModel> WareHouseShow()
        {
            return _idal.WareHouseShow();
        }
     
        //判断是否入库
        public int IsRuKu(int oid)
        {
            return _idal.IsRuKu(oid);
        }
        #endregion

        //退货
        #region

        //添加退货信息
        public int ReturndAdd(ReturndModel model) 
        {
            return _idal.ReturndAdd(model);
        }
        //显示退货信息
        public List<ReturndModel> ReturndShow()
        {
            return _idal.ReturndShow();
        }
        //删除退货信息
        public int ReturndShan(string ids) 
        {
            return _idal.ReturndShan(ids);
        }
        #endregion

        //入库
        #region

        //添加入库清单表
        public int RuChecklistAdd(RuchecklistModel model)
        {
            return _idal.RuChecklistAdd(model);
        }
        //添加临时库位详
        public int TempLocationWithAdd(LocationWithModel model)
        {
            return _idal.TempLocationWithAdd(model);
        }
        //查看临时库位详情
        public List<TempLocationWithModel> TempLocationWithShow()
        {
            return _idal.TempLocationWithShow();
        }
        //清空临时库位详情
        public int TempLocationWithDelete()
        {
            return _idal.TempLocationWithDelete();
        }
        //查看入库清单
        public List<RuchecklistModel> RuchecklistShow()
        {
            return _idal.RuchecklistShow();
        }
        //通过Id查看编号
        public string SearchCode(int id)
        {
            return _idal.SearchCode(id);

        }
        //查看入库清单详细
        public List<LocationWithModel> LocationWithShow(string code)
        {
            return _idal.LocationWithShow(code);
        }
        #endregion

        //出库
        #region

        //查找出库前商品
        public List<LocationWithModel> BeforeChuKu(int id)
        {
            return _idal.BeforeChuKu(id);
        }
        //出库过程
        public int HavingChuKu(int num, int sid, int lid)
        {
            return _idal.HavingChuKu(num, sid, lid);
        }
        //添加出库清单
        public int RetrievealAdd(RetrievealModel model)
        {
            return _idal.RetrievealAdd(model);
        }
        //显示出库清单表
        public List<RetrievealModel> RetrievealShow()
        {
            return _idal.RetrievealShow();
        }
        //添加出库清单详细表
        public int RetrievealDeitAdd(RetrievealDeitModel model)
        {
            return _idal.RetrievealDeitAdd(model);
        }
        //通过Id查找Code
        public string RetrievealSearchCode(int id)
        {
            return _idal.RetrievealSearchCode(id);
        }
        //查看出库清单详情
        public List<RetrievealDeitModel> RetrievealDeitShow(string code)
        {
            return _idal.RetrievealDeitShow(code);
        }
        //添加出库清单详细临时表
        public int TempRetrievealDeitAdd(TempRetrievealDeitModel model)
        {
            return _idal.TempRetrievealDeitAdd(model);
        }
        //显示出库清单详细临时表
        public List<TempRetrievealDeitModel> TempRetrievealDeitShow()
        {
            return _idal.TempRetrievealDeitShow();
        }
        //清空出库清单临时
        public int DeleteTempRetrievealDeit() 
        {
            return _idal.DeleteTempRetrievealDeit();
        }
        #endregion

        //调库
        #region

        public int LocationWithUpdate(LocationWithModel model)
        {
            return _idal.LocationWithUpdate(model);
        }

        public List<LocationWithModel> UpdateLocationShow(int pagIndex, int pagSize, string name, out int pagCount)
        {
            return _idal.UpdateLocationShow(pagIndex, pagSize, name, out pagCount);
        }
        #endregion
    }
}
