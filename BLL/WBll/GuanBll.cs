using BLL.IBll;
using DAL.IDal;
using Model;
using System;
using System.Collections.Generic;

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
        //绑定单位
        public List<UnitModel> UnitBang()
        {
            return _idal.UnitBang();
        }
    }
}
