using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IBll
{
    public interface IDengLuBLL
    {
        //用户 Userd 登录 注册 
        #region
        UserdModel UserdDenLuint(string username, string userpass);
        int UserdZhuChe(UserdModel model);
        #endregion
    }
}
