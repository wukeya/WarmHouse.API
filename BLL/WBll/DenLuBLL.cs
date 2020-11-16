using BLL.IBll;
using DAL.IDal;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.WBll
{
    public class DenLuBLL: IDengLuBLL
    {
        //依赖注入
        private IDengLuDal _idal;
        public DenLuBLL(IDengLuDal dal)
        {
            _idal = dal;
        }
        //用户 Userd 登录 注册 UserdZhuChe
        #region
        public UserdModel UserdDenLuint(string username, string userpass)
        {
            return _idal.UserdDenLuint(username, userpass);
        }
        //注册 
        public int UserdZhuChe(UserdModel model)
        {
            return _idal.UserdZhuChe(model);
        }
        #endregion
    }
}
