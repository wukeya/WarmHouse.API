using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class UserRoleModel
    {
        public int UserRoleId { get; set; }//用户角色Id
        public int UserId     { get; set; }//用户Id
        public int RoleId     { get; set; }//角色ID  
    }
}
