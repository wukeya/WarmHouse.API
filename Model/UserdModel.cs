using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserdModel
    {
        public int UserdId  { get; set; }//用户Id
        public string UserName { get; set; }//用户账号
        public string UserPass { get; set; }//用户密码
        public int UserFId { get; set; }//0客户  1管理员  2物流  3经理
    }
}
