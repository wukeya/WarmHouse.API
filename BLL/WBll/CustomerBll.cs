using Model;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.IDal;
using BLL.IBll;

namespace BLL.WBll
{
    public class CustomerBll:ICustomerBll
    {
        private ICustomerDal _customerDal;
        public CustomerBll(ICustomerDal customerDal) 
        {
            _customerDal = customerDal;
        }
        //添加选购清单
        public int SelectOrderAdd(SelectOrderModel model)
        {
            return _customerDal.SelectOrderAdd(model);
        }
        //添加选购详细
        public int SelectOrderDeitAdd(SelectOrderDeitModel model)
        {
            return _customerDal.SelectOrderDeitAdd(model);
        }
        //显示购物清单
        public List<SelectOrderModel> SelectOrderShow()
        {
            return _customerDal.SelectOrderShow();
        }
        //通过id查找code
        public string SelectOrderSerachCode(int id)
        {
            return _customerDal.SelectOrderSerachCode(id);
        }
        //显示购物清单详细
        public List<SelectOrderDeitModel> SelectOrderDeitShow(string code)
        {
            return _customerDal.SelectOrderDeitShow(code);
        }
    }
}
