using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDal
{
    public interface ICustomerDal
    {
        int SelectOrderAdd(SelectOrderModel model);
        int SelectOrderDeitAdd(SelectOrderDeitModel model);
        List<SelectOrderModel> SelectOrderShow();
        string SelectOrderSerachCode(int id);
        List<SelectOrderDeitModel> SelectOrderDeitShow(string code);
    }
}
