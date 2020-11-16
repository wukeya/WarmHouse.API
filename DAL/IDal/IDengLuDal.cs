using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IDal
{
    public interface IDengLuDal
    {
        //用户 Userd 登录 注册 
        #region
        UserdModel UserdDenLuint(string username, string userpass);
        int UserdZhuChe(UserdModel model);
        #endregion
    }
}
