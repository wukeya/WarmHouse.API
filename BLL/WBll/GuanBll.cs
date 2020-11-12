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
        //显示库位详情
        public List<LocationWithModel> LocationWithShow()
        {
            return _idal.LocationWithShow();
        }
        //判断是否入库
        public int IsRuKu(int oid)
        {
            return _idal.IsRuKu(oid);
        }
        //添加退货信息
        public  int ReturndAdd(ReturndModel model) 
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
      
       
    }
}
