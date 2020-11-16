using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.IBll;
using Model;
using Newtonsoft.Json;
namespace UI.API.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private  ICustomerBll _customerBll;
        public CustomerController(ICustomerBll customerBll) 
        {
            _customerBll = customerBll;
        }
        //添加选购清单
        [Route("SelectOrderAdd")]
        [HttpPost]
        public int SelectOrderAdd(string ff="")
        {
            try
            {
                SelectOrderModel model = JsonConvert.DeserializeObject<SelectOrderModel>(ff);
                _customerBll.SelectOrderAdd(model);
                var gids = model.Gids;
                var nums = model.Nums;
                var arr = gids.Split(',');
                var arr2 = nums.Split(',');
                //循环添加选购详细
                for (int i = 0; i < arr.Length; i++)
                {
                    //实例化选购详细
                    SelectOrderDeitModel model1 = new SelectOrderDeitModel();
                    model1.SelectOrderDeitCode = model.SelectOrderCode;
                    model1.SelectOrderDeitGid = Convert.ToInt32(arr[i]);
                    model1.SelectOrderDeitNum = Convert.ToInt32(arr2[i]);
                    _customerBll.SelectOrderDeitAdd(model1);
                }
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            
        }
      
        //显示购物清单
        [Route("SelectOrderShow")]
        [HttpGet]
        public List<SelectOrderModel> SelectOrderShow()
        {
            return _customerBll.SelectOrderShow();
        }
        //通过id查找code
        [Route("SelectOrderSerachCode")]
        [HttpGet]
        public string SelectOrderSerachCode(int id)
        {
            return _customerBll.SelectOrderSerachCode(id);
        }
        //显示购物清单详细
        [Route("SelectOrderDeitShow")]
        [HttpGet]
        public List<SelectOrderDeitModel> SelectOrderDeitShow(string code)
        {
            return _customerBll.SelectOrderDeitShow(code);
        }

    }
}
