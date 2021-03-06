﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using BLL.IBll;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using DAL;

namespace UI.API.Controllers
{
    [Route("Guan")]
    [ApiController]
    public class GuanController : ControllerBase
    {
        JWTHelper jwt = new JWTHelper();
        public IWebHostEnvironment _iwebh;
        //依赖注入
        private IGuanBLL _ibll;
        public GuanController(IGuanBLL ibll,IWebHostEnvironment iwebh)
        {
            _ibll = ibll;
            _iwebh = iwebh;
        }


        //绑定单位
        [Route("UnitBang")]
        [HttpGet]
        public List<UnitModel> UnitBang()
        {
            return _ibll.UnitBang();
        }

        [Route("GoodsAdd")]
        [HttpPost]
        //添加商品
        public int GoodsAdd(string ff="")
        {
            GoodsModel model= JsonConvert.DeserializeObject<GoodsModel>(ff);
            model.GoodsState = 1;
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wort = _iwebh.ContentRootPath;
                    var filename = Path.Combine(wort, "wwwroot/img/", item.FileName);
                    model.GoodsImg = "/img/" + item.FileName;
                    using (var s = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(s);
                    }
                }
            }
            return _ibll.GoodsAdd(model);
        }

        //删除商品
        [Route("GoodsShan")]
        [HttpGet]
        public int GoodsShan(string ids)
        {
            return _ibll.GoodsShan(ids);
        }

        //反填商品
        [Route("GoodsFan")]
        [HttpGet]
        public GoodsModel GoodsFan(int id)
        {
            return _ibll.GoodsFan(id);
        }

        //修改商品
        [Route("GoodsUpdate")]
        [HttpPost]
        public int GoodsUpdate(string ff="")
        {
            GoodsModel model = JsonConvert.DeserializeObject<GoodsModel>(ff);
            var file = Request.Form.Files;
            foreach (var item in file)
            {
                if (item.Length > 0)
                {
                    var wort = _iwebh.ContentRootPath;
                    var filename = Path.Combine(wort, "wwwroot/img/", item.FileName);
                    model.GoodsImg = "/img/" + item.FileName;
                    using (var s = new FileStream(filename, FileMode.Create))
                    {
                        item.CopyTo(s);
                    }
                }
            }
            return _ibll.GoodsUpdate(model);
        }

        //显示商品
        [Route("GoodsShow")]
        [HttpGet]
        public  IActionResult GooodsShow(int pagIndex=1, int pagSize=3, int typeId=0, string name="")
        {
            if (name==null)
            {
                name = "";
            }
            int pagCount = 0;
            List<GoodsModel> list= _ibll.GooodsShow(pagIndex, pagSize, typeId, name, out pagCount);
            return Ok(new { a = list, pagCount = pagCount });
        }
        //修改商品状态
        [Route("GoodsUpdateState")]
        [HttpGet]
        public int GoodsUpdateState(int state, int id)
        {
            return _ibll.GoodsUpdateState(state, id);
        }

        //绑定类型
        [Route("TypeBang")]
        [HttpGet]
        public List<TypeModel> TypeBanag()
        {
            return _ibll.TypeBanag();
        }
        //绑定供应商
        [Route("SuppleBang")]
        [HttpGet]
        public List<SuppleModel> SuppleBang()
        {
            return _ibll.SuppleBang();
        }
        [Route("EquipmentAdd")]
        [HttpPost]
        //添加设备
        public int EquipmentAdd(string ff="")
        {
            EquipmentModel model = JsonConvert.DeserializeObject<EquipmentModel>(ff);
            return _ibll.EquipmentAdd(model);
        }
        //显示设备
        [Route("EquipmentShow")]
        [HttpGet]
        public  IActionResult EquipmentShow(int pagIndex=1, int pagSize=3, string name="")
        {
            int pagCount = 0;
            List<EquipmentModel> list= _ibll.EquipmentShow(pagIndex, pagSize, name, out pagCount);
            return Ok(new { a = list, pagCount = pagCount });
        }
        //删除设备
        [Route("EquipmentShan")]
        [HttpGet]
        public int EquipmentShan(string ids)
        {
            return _ibll.EquipmentShan(ids);
        }
        //反填设备
        [Route("EquipmentFan")]
        [HttpGet]
        public EquipmentModel EquipmentFan(int id)
        {
            return _ibll.EquipmentFan(id);
        }
        //修改设备
        [Route("EquipmentUpdate")]
        [HttpGet]
        public int EquipmentUpdate(EquipmentModel model)
        {
            return _ibll.EquipmentUpdate(model);
        }
        //修改设备状态
        [Route("EquipmentStateUpdate")]
        [HttpGet]
        //修改设备状态
        public int EquipmentStateUpdate(int state, int id)
        {
            return _ibll.EquipmentStateUpdate(state, id);
        }
        //添加报损
        [Route("ReportAdd")]
        [HttpPost]
        public int ReportAdd(string ff="")
        {
           
            try
            {
                ReportModel model = JsonConvert.DeserializeObject<ReportModel>(ff);
                model.ReportedTime = DateTime.Now;
                var numarr = model.nums.ToString().Split(',');
                var gidarr = model.gids.ToString().Split(',');
                //循环添加
                for (int i = 0; i < numarr.Length; i++)
                {
                    //实例化ReportModel
                    ReportModel model1 = new ReportModel();
                    model1.ReportedTime = DateTime.Now;
                    model1.ReportedNum = Convert.ToInt32(numarr[i]);
                    model1.ReportedGid = Convert.ToInt32(gidarr[i]);
                    _ibll.ReportAdd(model1);
                    //根据库位详情Id减去商品数量
                    _ibll.GoodsNumReduce(model1.ReportedGid, model1.ReportedNum);

                }
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }
        
        //显示报损
        [Route("ReportShow")]
        [HttpGet]
        public IActionResult ReportShow(int pagIndex=1, int pagSize=5)
        {   
            List<ReportModel> list= _ibll.ReportShow(pagIndex, pagSize);
            var pagCount = list.Count;
            //分页显示
            list = list.Skip((pagIndex - 1) * pagSize).Take(pagSize).ToList();
            return Ok(new { a = list, pagCount = pagCount });
        }
        //删除报损
        [Route("ReportShan")]
        [HttpGet]
        public int ReportShan(string ids)
        {
            return _ibll.ReportShan(ids);
        }
        //反弹报损
        [Route("ReportFan")]
        [HttpGet]
        public ReportModel ReportFan(int id)
        {
            return _ibll.ReportFan(id);
        }
        //修改报损
        [Route("ReportUpdate")]
        [HttpPost]
        public int ReportUpdate(ReportModel model)
        {
            return _ibll.ReportUpdate(model);
        }
        //添加订单和详情表
        [Route("OrderDeitAllAdd")]
        [HttpPost]
        public int OrderDeitAllAdd(string ff = "")
        {
            try
            {
                //把字符串序列化为集合
                PurchaseModel model = JsonConvert.DeserializeObject<PurchaseModel>(ff);
                var ids = model.ids;
                var nums = model.nums;
                //执行添加订单方法并获得自增Id
                int pid = _ibll.PurchaseAdd(model);
                //执行添加详细表
                _ibll.OrderDeits(pid, ids,nums);
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //显示采购订单表
        [Route("PurchaseShow")]
        [HttpGet]
        public List<PurchaseModel> PurchaseShow()
        {
            return _ibll.PurchaseShow();
        }
        //查看采购订单详情
        [Route("OrderDeitShow")]
        [HttpGet]
        public List<OrderDeitModel> OrderDeitShow(int pid)
        {
            return _ibll.OrderDeitShow(pid);
        }
        //添加库位
        [Route("LocationAdd")]
        [HttpPost]
        public int LocationAdd(LocationModel model)
        {
            return _ibll.LocationAdd(model);
        }
        //显示库位
        [Route("LocationShow")]
        [HttpGet]
        public List<LocationModel> LocationShow(int wid)
        {
            return _ibll.LocationShow(wid);
        }

        //添加入库清单表
        [Route("RuchecklistAdd")]
        [HttpPost]
        //添加入库清单表
        public int RuChecklistAdd(string ff="")
        {
            try
            {
                RuchecklistModel model = JsonConvert.DeserializeObject<RuchecklistModel>(ff);
                _ibll.RuChecklistAdd(model);
                //查看临时库位详情
                List<TempLocationWithModel> list = _ibll.TempLocationWithShow();
                //循环把临时表数据加入库位详情表
                foreach (var item in list)
                {
                    //实例化库位详情类
                    LocationWithModel model1 = new LocationWithModel();
                    model1.LocationRuCode = model.RuchecklistCode;
                    model1.LocationState = item.LocationState;
                    model1.LocationLid = item.LocationLid;
                    model1.LocationWid = item.LocationWid;
                    model1.LocationWithOid = item.LocationWithOid;
                    //添加入库详细表
                    _ibll.LocationWithAdd(model1);
                    //清空临时详细表
                    _ibll.TempLocationWithDelete();
                }
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        //添加临时库位详
        [Route("TempLocationWithAdd")]
        [HttpPost]
        public int TempLocationWithAdd(string ff="")
        {
            LocationWithModel model = JsonConvert.DeserializeObject<LocationWithModel>(ff);
            model.LocationState = 0;
            //修改订单详情状态
            int state = 1;
            _ibll.OrderUpdateState(state, model.LocationWithOid);
            return _ibll.TempLocationWithAdd(model);
        }
        //显示仓库
        [Route("WareHouseShow")]
        [HttpGet]
        public List<WareHouseModel> WareHouseShow()
        {
            return _ibll.WareHouseShow();
        }
        //显示仓库详细
        [Route("WareHouseDeitShow")]
        [HttpGet]
        public List<LocationWithModel> WareHouseDeitShow(int id)
        {
            return _ibll.WareHouseDeitShow(id);
        }
        //添加仓库
        [Route("WarmHouseAdd")]
        [HttpPost]
        public int WarmHouseAdd(string ff="")
        {
            try
            {
                WareHouseModel model = JsonConvert.DeserializeObject<WareHouseModel>(ff);
                //添加仓库
                int i = _ibll.WarmHouseAdd(model);
                //临时库位显示
                List<LocationModel> list = _ibll.TemLocationShow();
                //循环加入库位
                foreach (var item in list)
                {
                    //实例化LocationModel
                    LocationModel model1 = new LocationModel();
                    model1.LocationWid = i;
                    model1.LocationName = item.LocationName;
                    model1.LocationMin = item.LocationMin;
                    model1.LocationMax = item.LocationMax;
                    //添加库位
                    _ibll.LocationAdd(model1);
                    
                }
                //清空临时库位
                _ibll.TemLocationDelete();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //添加临时库位
        [Route("TemLocationAdd")]
        [HttpPost]
        public int TemLocationAdd(string ff="")
        {
            LocationModel model = JsonConvert.DeserializeObject<LocationModel>(ff);
            model.LocationWid = 0;
            return _ibll.TemLocationAdd(model);
        }
        //显示临时库位
        [Route("TemLocationShow")]
        [HttpGet]
        public List<LocationModel> TemLocationShow()
        {
            return _ibll.TemLocationShow();
        }
       
        //查看入库清单
        [Route("RuchecklistShow")]
        [HttpGet]
        public List<RuchecklistModel> RuchecklistShow()
        {
            return _ibll.RuchecklistShow();
        }
        //通过Id查看编号
        [Route("SearchCode")]
        [HttpGet]
        public string SearchCode(int id)
        {
            return _ibll.SearchCode(id);

        }
        //查看入库清单详细
        [Route("LocationWithShow")]
        [HttpGet]
        public List<LocationWithModel> LocationWithShow(string code)
        {
            return _ibll.LocationWithShow(code);
        }
        //查看全部入库清单详细
        [Route("AllLocationWithShow")]
        [HttpGet]
        public IActionResult AllLocationWithShow(int pagIndex=1,int pagSize=4)
        {
            List<LocationWithModel> list= _ibll.AllLocationWithShow();
            //获取总行数
            int count = list.Count;
            //执行分页
            list = list.Skip((pagIndex - 1) * pagSize).Take(pagSize).ToList();
            return Ok(new { a = list, pagCount = count });
        }
        //判断是否入库
        [Route("IsRuku")]
        [HttpGet]
        public int IsRuKu(int oid)
        {
            return _ibll.IsRuKu(oid);
        }
        //添加退货信息
        [Route("ReturndAdd")]
        [HttpPost]
        public int ReturndAdd(string ff="")
        {
            ReturndModel model = JsonConvert.DeserializeObject<ReturndModel>(ff);
            int state = 2;
            //修改订单详细状态
            _ibll.OrderUpdateState(state, model.ReturnOid);
            return _ibll.ReturndAdd(model);
        }
        //显示退货信息
        [Route("ReturndShow")]
        [HttpGet]
        public List<ReturndModel> ReturndShow()
        {
            return _ibll.ReturndShow();
        }
        //删除退货信息
        [Route("ReturndShan")]
        [HttpGet]
        public int ReturndShan(string ids)
        {
            return _ibll.ReturndShan(ids);
        }
        //查找出库前商品
        [Route("BeforeChuKu")]
        [HttpGet]
        public List<LocationWithModel> BeforeChuKu(int id)
        {
            return _ibll.BeforeChuKu(id);
        }
        //出库过程
        [HttpGet("HavingChuKu")]
        [HttpGet]
        public int HavingChuKu(int num, int sid, int lid)
        {
            try
            {
                _ibll.HavingChuKu(num, sid, lid);
                //添加到出库清单详细临时
                //实例化Model
                TempRetrievealDeitModel model = new TempRetrievealDeitModel();
                model.TempRetrievealDeitNum = num;
                model.TempRetrievealDeitLid = lid;
                _ibll.TempRetrievealDeitAdd(model);
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //添加出库清单
        [Route("RetrievealAdd")]
        [HttpPost]
        public int RetrievealAdd(string ff="")
        {
            try
            {
                RetrievealModel model = JsonConvert.DeserializeObject<RetrievealModel>(ff);
                //显示出库清单详细临时表
               List<TempRetrievealDeitModel> list= _ibll.TempRetrievealDeitShow();
                model.RetrievealState = 0;
                //添加出库清单
                _ibll.RetrievealAdd(model);
                //循环添加出库清单详细表
                foreach (var item in list)
                {
                    //实例化出库清单详细表
                    RetrievealDeitModel model1 = new RetrievealDeitModel();
                    model1.RetrievealDeitCode = model.RetrievealCode;
                    model1.RetrievealDeitLid = item.TempRetrievealDeitLid;
                    model1.RetrievealDeitNum = item.TempRetrievealDeitNum;
                    _ibll.RetrievealDeitAdd(model1);
                }
                //清空出库清单临时表
                _ibll.DeleteTempRetrievealDeit();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        //显示出库清单表
        [Route("RetrievealShow")]
        [HttpGet]
        public List<RetrievealModel> RetrievealShow()
        {
            return _ibll.RetrievealShow();
        }
        //添加出库清单详细表
        [Route("RetrievealDeitAdd")]
        [HttpPost]
        public int RetrievealDeitAdd(RetrievealDeitModel model)
        {
            return _ibll.RetrievealDeitAdd(model);
        }
        //通过Id查找Code
        [Route("RetrievealSearchCode")]
        [HttpGet]
        public string RetrievealSearchCode(int id)
        {
            return _ibll.RetrievealSearchCode(id);
        }
        //查看出库清单详情
        [Route("RetrievealDeitShow")]
        [HttpGet]
        public List<RetrievealDeitModel> RetrievealDeitShow(string code)
        {
            return _ibll.RetrievealDeitShow(code);
        }
       
           
       


    }
}
