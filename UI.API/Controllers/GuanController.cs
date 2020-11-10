using System;
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

namespace UI.API.Controllers
{
    [Route("Guan")]
    [ApiController]
    public class GuanController : ControllerBase
    {
        private IWebHostEnvironment _iwebh;
        //依赖注入
        private IGuanBLL _ibll;
        public GuanController(IGuanBLL ibll)
        {
            _ibll = ibll;
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
        public int GoodsAdd(GoodsModel model)
        {
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
        public int GoodsUpdate(GoodsModel model)
        {
            return _ibll.GoodsUpdate(model);
        }

        //显示商品
        [Route("GoodsShow")]
        [HttpGet]
        public List<GoodsModel> GooodsShow(int pagIndex=1, int pagSize=3, int typeId=5, string name="")
        {
            int pagCount = 0;
            return _ibll.GooodsShow(pagIndex, pagSize, typeId, name, out pagCount);
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
        public int EquipmentAdd(EquipmentModel model)
        {
            return _ibll.EquipmentAdd(model);
        }
        //显示设备
        [Route("EquipmentShow")]
        [HttpGet]
        public List<EquipmentModel> EquipmentShow(int pagIndex=1, int pagSize=3, string name="")
        {
            int pagCount = 0;
            return _ibll.EquipmentShow(pagIndex, pagSize, name, out pagCount);
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
        //添加报损
        [Route("ReportAdd")]
        [HttpPost]
        public int ReportAdd(ReportModel model)
        {
            return _ibll.ReportAdd(model);
        }
        //显示报损
        [Route("ReportShow")]
        [HttpGet]
        public List<ReportModel> ReportShow(int pagIndex, int pagSize, out int pagCount)
        {
            return _ibll.ReportShow(pagIndex, pagSize, out pagCount);
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

        /*
        //添加报损
        [Route("ReportAdd")]
        [HttpPost]
        public int PurchaseAdd(PurchaseModel model)
        {
            return _ibll.PurchaseAdd(model);
        }
        //显示报损
        [Route("ReportShow")]
        [HttpGet]
        public List<PurchaseModel> PurchaseShow(int purchaseId, int purchaseUid, int purchasePid, string purchaseCode, DateTime purchaseTime, int purchaseState, out int pagCount)
        {
            return _ibll.PurchaseShow(purchaseId, purchaseUid, purchasePid, purchaseCode, purchaseTime, purchaseState,out pagCount);
        }
        //删除报损
        [Route("ReportShan")]
        [HttpGet]
        public int PurchaseShan(string ids)
        {
            return _ibll.PurchaseShan(ids);
        }
        //反填报损
        [Route("ReportFan")]
        [HttpGet]
        public PurchaseModel PurchaseFan(int id)
        {
            return _ibll.PurchaseFan(id);
        }
        //修改报损
        [Route("ReportUpdate")]
        [HttpPost]
        public int PurchaseUpdate(PurchaseModel model)
        {
            return _ibll.PurchaseUpdate(model);
        }
        */
    }
}
